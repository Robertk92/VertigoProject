using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    private readonly List<AttachmentSlot> _slots = new List<AttachmentSlot>();

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

    public void Equip(AttachmentSlotId slotId, Item attachable)
    {
        AttachmentSlot slot = _slots.FirstOrDefault(x => x.SlotId == slotId);
        Debug.AssertFormat(slot != null, string.Format("No slot found with slot id '{0}'", slotId));

        if(_equippedObjects[slotId] != null)
        {
            GameObject.Destroy(_equippedObjects[slotId]);
        }

        _equippedObjects[slotId] = GameObject.Instantiate(attachable.ModelPrefab, slot.BoneTransform);
    }
}
