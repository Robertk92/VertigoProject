using System;
using System.Collections.Generic;

[Serializable]
public struct EffectsEventPair 
{
    public EffectorEvent effectorEvent;
    public List<Effect> effects;
}
