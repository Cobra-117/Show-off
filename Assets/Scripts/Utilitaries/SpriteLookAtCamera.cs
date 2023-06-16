using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteLookAtCamera : MonoBehaviour
{
    private GameObject mainCamera;

    private void Start()
    {
        // Assuming you want the main camera to be the target
        mainCamera = GameObject.FindGameObjectWithTag("cmCam");
    }

    private void LookAtCam()
    {
        // Calculate the direction from the object to the camera
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;

        // Calculate the rotation to look at the camera
        Quaternion rotationToCamera = Quaternion.LookRotation(directionToCamera, Vector3.up);

        // Apply the rotation to the object
        transform.rotation = rotationToCamera;
    }

    private void Update()
    {
        if(mainCamera)
        LookAtCam();
    }
}