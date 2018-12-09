
using UnityEngine;

[CreateAssetMenu]
public class ObjectSpawnEffect : Effect
{
    [SerializeField]
    private GameObject _prefab;
    
    public override void Apply(GameObject target)
    {
        GameObject spawned = GameObject.Instantiate(_prefab);
        spawned.transform.position = target.transform.position;
    }
}
