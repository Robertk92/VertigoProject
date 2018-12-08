using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    [SerializeField]
    private PlayerInputController _playerInputControllerPrefab;

    [SerializeField]
    private Player _playerPrefab;
    
    private void Awake()
    {
        Instance = this; // :)

        PlayerInputController playerInputController = Instantiate(_playerInputControllerPrefab);
        Player player = Instantiate(_playerPrefab);

        GameObject playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn");
        Debug.AssertFormat(playerSpawn, "Failed to spawn player: No player spawn found in the scene");

        player.transform.position = playerSpawn.transform.position;
        player.transform.rotation = playerSpawn.transform.rotation;

        playerInputController.Possess(player);
    }
}
