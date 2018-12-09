using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public event Action OnAnimEventReleaseThrowable = delegate { };
    public event Action OnAnimEventThrowEnded = delegate { };

    private void ReleaseThrowable()
    {
        OnAnimEventReleaseThrowable.Invoke();
    }

    private void ThrowEnded()
    {
        OnAnimEventThrowEnded.Invoke();
    }
}
