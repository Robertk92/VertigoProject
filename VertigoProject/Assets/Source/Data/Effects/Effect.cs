
using UnityEngine;

/**
 * An effect is a small piece of logic that acts as a delegate
 * This makes it easy to add commonly used small pieces of code to events
 */
public abstract class Effect : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
