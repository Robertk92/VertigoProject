using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class EquipmentManager
{
    private readonly Dictionary<AttachmentSlotId, GameObject> _equippedObjects = new Dictionary<AttachmentSlotId, GameObject>();
    /// <summary>
    /// The spawned game objects of the items that are currently equipped
    /// </summary>
    public IEnumerable<KeyValuePair<AttachmentSlotId, GameObject>> EquippedObjects { get { return _equippedObjects; } }

    private readonly List<Item> _inventory = new List<Item>();

    /// <summary>
    /// The items that is being carried (not the actual game object)
    /// </summary>
    public IEnumerable<Item> Inventory { get { return _inventory; } }

    private readonly List<AttachmentSlot> _slots;

    public event Action<Item> OnEquipped = delegate { };

    public EquipmentManager(List<AttachmentSlot> slots)
    {
        _slots = slots;
        
        // Fill equipment dictionary so the keys exist
        foreach(AttachmentSlotId slot in Enum.GetValues(typeof(AttachmentSlotId)))
        {
            _equippedObjects.Add(slot, null);
        }
    }

    public GameObject GetEquipmentInSlot(AttachmentSlotId slotId)
    {
        return _equippedObjects[slotId];
    }

    public void AddToInventory(Item item)
    {
        _inventory.Add(item);
    }

    public void RemoveFromInventory(int index)
    {
        _inventory.RemoveAt(index);
    }

    public void Equip(AttachmentSlotId slotId, int inventoryIndex)
    {
        Debug.AssertFormat(inventoryIndex < _inventory.Count && inventoryIndex >= 0, 
            string.Format("Equip failed: inventory index '{0}' is outside the bounds of the inventory", inventoryIndex));

        Item item = _inventory[inventoryIndex];
        AttachmentSlot slot = _slots.FirstOrDefault(x => x.SlotId == slotId);
        Debug.AssertFormat(slot != null, string.Format("No slot found with slot id '{0}'", slotId));

        if(_equippedObjects[slotId] != null)
        {
            GameObject.Destroy(_equippedObjects[slotId].gameObject);
        }
        
        GameObject spawnedItem = GameObject.Instantiate(item.Prefab);
        _equippedObjects[slotId] = spawnedItem;
        spawnedItem.transform.SetPositionAndRotation(
            slot.BoneTransform.position,
            slot.BoneTransform.rotation);
        spawnedItem.transform.SetParent(slot.BoneTransform);

        
        spawnedItem.transform.localPosition = item.AttachmentPositionOffset;
        spawnedItem.transform.localRotation = Quaternion.Euler(item.AttachmentRotationOffset);
        OnEquipped.Invoke(item);
    }
}
