
using UnityEngine;

[System.Serializable]
public class ItemStateInfo
{
    public bool Depleted { get; set; }
}

/**
 * The actual physical item that contains both shared and non-shared state
 */
public abstract class Item : MonoBehaviour
{
    public abstract ItemContext GetContext();
    public abstract ItemStateInfo GetStateInfo();

    /// <summary>
    /// Called by the EquipmentManager to apply the non-shared state to a newly created item (retrieved from the inventory)
    /// </summary>
    public abstract void InitStateInfo(ItemStateInfo stateInfo);

    /// <summary>
    /// Called when the Use button is pressed, return value determines whether or not the item should be consumed upon usage
    /// </summary>
    public virtual bool Use() { return false;  }
}
