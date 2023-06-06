using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerToCamera : MonoBehaviour
{
    GameObject cMCamera;
    // Start is called before the first frame update
    void Start()
    {
        cMCamera = GameObject.FindGameObjectWithTag("TargGroup");
        Cinemachine.CinemachineTargetGroup targetGroup =
        cMCamera.GetComponent<Cinemachine.CinemachineTargetGroup>();
        //cMCamera.GetComponent<Cine>
        for (int i = 0; i < transform.childCount;i ++) {
            if (gameObject.activeInHierarchy && tag == "Player") {
                targetGroup.AddMember(transform, 1, 0);
            }
        }
    }

    void Update()
    {

    }
}
