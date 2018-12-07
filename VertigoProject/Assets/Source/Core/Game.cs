using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    [SerializeField]
    private Database _database;
    public Database Database { get { return _database; } }

    private void Awake()
    {
        Instance = this; // :)
    }

}
