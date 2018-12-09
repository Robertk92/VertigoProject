﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    [SerializeField]
    private PlayerInputController _playerInputControllerPrefab;

    [SerializeField]
    private Player _playerPrefab;

    public Player Player { get; private set; }
    public PlayerInputController PlayerInputController { get; private set;}

    private void Awake()
    {
        Instance = this; // :)

        PlayerInputController = Instantiate(_playerInputControllerPrefab);
        Player = Instantiate(_playerPrefab);

        GameObject playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn");
        Debug.AssertFormat(playerSpawn, "Failed to spawn player: No player spawn found in the scene");

        Player.transform.position = playerSpawn.transform.position;
        Player.transform.rotation = playerSpawn.transform.rotation;

        PlayerInputController.Possess(Player);
    }
}
