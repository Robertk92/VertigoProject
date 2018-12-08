
using UnityEngine;

public class AmmoClip : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;
    public GameObject ProjectilePrefab { get { return _projectilePrefab; } }
    
    public int projectileCount;
}
