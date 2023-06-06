using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNameSpawner : MonoBehaviour
{
    public Transform[] spawnLocations;

    void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player " + playerInput.playerIndex + 1 + " joined");

        playerInput.gameObject.transform.SetParent(transform.Find("Players UI"));
        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;
        playerInput.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        //playerInput.gameObject.GetComponent<PlayerDetails>().startPosition = spawnLocations[playerInput.playerIndex].position;
        //SceneManagerScript.controllerCount++;
    }
}
