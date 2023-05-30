using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;

    void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player " + playerInput.playerIndex + " joined");

        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;
        playerInput.gameObject.GetComponent<PlayerDetails>().startPosition = spawnLocations[playerInput.playerIndex].position;
    }
}
