using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class EquipmentManager
{
    private readonly Dictionary<AttachmentSlotId, Item> _equippedItems = new Dictionary<AttachmentSlotId, Item>();
    /// <summary>
    /// The spawned game objects of the items that are currently equipped
    /// </summary>
    public IEnumerable<KeyValuePair<AttachmentSlotId, Item>> EquippedItems { get { return _equippedItems; } }

    private readonly List<ItemContext> _inventory = new List<ItemContext>();

    /// <summary>
    /// The items that is being carried (not the actual game object)
    /// </summary>
    public IEnumerable<ItemContext> Inventory { get { return _inventory; } }

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

    public void AddToInventory(ItemContext item)
    {
        _inventory.Add(item);
    }

    public void RemoveFromInventory(ItemContext item)
    {
        _inventory.Remove(item);
    }

    public T GetInventoryItemByType<T>() where T : ItemContext
    {
        foreach (ItemContext item in Inventory)
        {
            if(item.GetType() == typeof(T))
            {
                return (T)item;
            }
        }
        return null;
    }

    public ItemContext GetInventoryItemByName(string name)
    {
        foreach (ItemContext item in _inventory)
        {
            if(item.name == name)
            {
                return item;
            }
        }
        return null;
    }

    public Item Equip(AttachmentSlotId slotId, ItemContext item)
    {
        if (_slotLocks[slotId])
        {
            return null;
        }

        if(!Inventory.Contains(item))
        {
            return null;
        }
        
        AttachableContext attachable = (AttachableContext)item;
        Debug.AssertFormat(attachable, string.Format("Failed to equip: item '{0}' is not attachable", item.name));
        
        AttachmentSlot slot = _slots.FirstOrDefault(x => x.SlotId == slotId);
        Debug.AssertFormat(slot != null, string.Format("No slot found with slot id '{0}'", slotId));

        if(_equippedItems[slotId] != null)
        {
            AddToInventory(_equippedItems[slotId].GetItemContext());
            GameObject.Destroy(_equippedItems[slotId].gameObject);
        }
        
        Item spawnedItem = GameObject.Instantiate(item.Prefab);
        _equippedItems[slotId] = spawnedItem;

        spawnedItem.transform.SetPositionAndRotation(
            slot.BoneTransform.position,
            slot.BoneTransform.rotation);
        spawnedItem.transform.SetParent(slot.BoneTransform);
        spawnedItem.transform.localPosition = attachable.AttachmentPositionOffset;
        spawnedItem.transform.localRotation = Quaternion.Euler(attachable.AttachmentRotationOffset);

        RemoveFromInventory(item);

        OnEquipped.Invoke(item);
        return spawnedItem;
    }
}
