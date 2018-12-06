using System;
using UnityEngine;

[Serializable]
public class AttachmentSlot 
{
    [SerializeField]
    private AttachmentSlotId _slotId;
    public AttachmentSlotId SlotId { get { return _slotId; } }

    [SerializeField]
    private Transform _boneTransform;
    public Transform BoneTransform { get { return _boneTransform; } }
}
