using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class InventoryItem
{
    public readonly ItemContext context;
    public readonly ItemStateInfo stateInfo;

    public InventoryItem(ItemContext context, ItemStateInfo stateInfo)
    {
        this.context = context;
        this.stateInfo = stateInfo;
    }
}

public class EquipmentManager
{
    private readonly Dictionary<AttachmentSlotId, Item> _equippedItems = new Dictionary<AttachmentSlotId, Item>();
    /// <summary>
    /// The spawned game objects of the items that are currently equipped
    /// </summary>
    public IEnumerable<KeyValuePair<AttachmentSlotId, Item>> EquippedItems { get { return _equippedItems; } }

    private readonly List<InventoryItem> _inventory = new List<InventoryItem>();

    /// <summary>
    /// The items that is being carried (not the actual game object)
    /// </summary>
    public IEnumerable<InventoryItem> Inventory { get { return _inventory; } }

    private readonly List<AttachmentSlot> _slots;
    private readonly Dictionary<AttachmentSlotId, bool> _slotLocks;

    public event Action<ItemContext> OnEquipped = delegate { };
    
    public EquipmentManager(List<AttachmentSlot> slots)
    {
        _slots = slots;
        _slotLocks = new Dictionary<AttachmentSlotId, bool>();
        
        // Fill dictionaries so the keys exist
        foreach(AttachmentSlotId slot in Enum.GetValues(typeof(AttachmentSlotId)))
        {
            _equippedItems.Add(slot, null);
            _slotLocks.Add(slot, false);
        }
    }

    public void LockSlot(AttachmentSlotId slotId)
    {
        _slotLocks[slotId] = true;
    }

    public void UnlockSlot(AttachmentSlotId slotId)
    {
        _slotLocks[slotId] = false;
    }

    public Item GetEquipmentInSlot(AttachmentSlotId slotId)
    {
        return _equippedItems[slotId];
    }

    public void AddToInventory(InventoryItem inventoryItem)
    {
        _inventory.Add(inventoryItem);
    }

    public void RemoveFromInventory(InventoryItem inventoryItem)
    {
        _inventory.Remove(inventoryItem);
    }

    public InventoryItem GetInventoryItemByName(string name)
    {
        foreach (InventoryItem item in _inventory)
        {
            if(item.context.name == name)
            {
                return item;
            }
        }
        return null;
    }

    public void UnEquip(AttachmentSlotId slotId)
    {
        Item equipped = _equippedItems[slotId];
        if (equipped != null)
        {
            _equippedItems[slotId] = null;
            equipped.transform.SetParent(null);
        }
    }

    public Item Equip(AttachmentSlotId slotId, InventoryItem inventoryItem)
    {
        if (_slotLocks[slotId])
        {
            return null;
        }

        if(!Inventory.Contains(inventoryItem))
        {
            return null;
        }
        
        AttachableContext attachable = (AttachableContext)inventoryItem.context;
        Debug.AssertFormat(attachable, string.Format("Failed to equip: item '{0}' is not attachable", inventoryItem.context.name));
        
        AttachmentSlot slot = _slots.FirstOrDefault(x => x.SlotId == slotId);
        Debug.AssertFormat(slot != null, string.Format("No slot found with slot id '{0}'", slotId));

        if(_equippedItems[slotId] != null)
        {
            if (!_equippedItems[slotId].GetStateInfo().Depleted)
            {
                // Unequip currently equipped and re-add to the inventory
                AddToInventory(new InventoryItem(
                    _equippedItems[slotId].GetContext(),
                    _equippedItems[slotId].GetStateInfo()));
            }
            GameObject.Destroy(_equippedItems[slotId].gameObject);
        }
        
        // Spawn and equip item from inventory
        Item spawnedItem = GameObject.Instantiate(inventoryItem.context.Prefab);
        _equippedItems[slotId] = spawnedItem;
        if (inventoryItem.stateInfo != null)
        {
            _equippedItems[slotId].InitStateInfo(inventoryItem.stateInfo);
        }

        spawnedItem.transform.SetPositionAndRotation(
            slot.BoneTransform.position,
            slot.BoneTransform.rotation);
        spawnedItem.transform.SetParent(slot.BoneTransform);
        spawnedItem.transform.localPosition = attachable.AttachmentPositionOffset;
        spawnedItem.transform.localRotation = Quaternion.Euler(attachable.AttachmentRotationOffset);

        // Remove inventory item of equiped item
        RemoveFromInventory(inventoryItem);

        OnEquipped.Invoke(inventoryItem.context);
        return spawnedItem;
    }
}
