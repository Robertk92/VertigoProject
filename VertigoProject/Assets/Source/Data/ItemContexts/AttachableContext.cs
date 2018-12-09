using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttachableContext : ItemContext
{
    [SerializeField]
    private Vector3 _attachmentPositionOffset;
    public Vector3 AttachmentPositionOffset { get { return _attachmentPositionOffset; } }

    [SerializeField]
    private Vector3 _attachmentRotationOffset;
    public Vector3 AttachmentRotationOffset { get { return _attachmentRotationOffset; } }
}
