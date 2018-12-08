using System;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField]
    private GameObject _prefab;
    public GameObject Prefab { get { return _prefab; } }

    [SerializeField]
    private Vector3 _attachmentPositionOffset;
    public Vector3 AttachmentPositionOffset { get { return _attachmentPositionOffset; } }

    [SerializeField]
    private Vector3 _attachmentRotationOffset;
    public Vector3 AttachmentRotationOffset { get { return _attachmentRotationOffset; } }
}
