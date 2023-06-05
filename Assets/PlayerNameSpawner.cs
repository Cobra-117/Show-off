using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNameSpawner : MonoBehaviour
{
    public Transform[] spawnLocations;

    void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player " + playerInput.playerIndex + " joined");

        playerInput.gameObject.transform.SetParent(this.transform);
        playerInput.gameObject.GetComponent<TextEditor>().playerID = playerInput.playerIndex;
        playerInput.gameObject.GetComponent<TextEditor>().startPosition = spawnLocations[playerInput.playerIndex].position;
    }
}
