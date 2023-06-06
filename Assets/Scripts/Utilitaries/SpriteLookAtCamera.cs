using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLookAtCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        // Assuming you want the main camera to be the target
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Calculate the direction from the object to the camera
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;

        // Calculate the rotation to look at the camera
        Quaternion rotationToCamera = Quaternion.LookRotation(directionToCamera, Vector3.up);

        // Apply the rotation to the object
        transform.rotation = rotationToCamera;
    }
}