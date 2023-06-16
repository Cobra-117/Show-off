using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddPlayerToCamera : MonoBehaviour
{
    GameObject cMCamera;
    Cinemachine.CinemachineTargetGroup targetGroup;
    public bool hasInit = false;
    bool isPlayscene = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable()
    {
        Debug.Log("test");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Update()
    {
        Debug.Log("child count: " + transform.childCount.ToString());
        if (!isPlayscene || hasInit)
            return;
        for (int i = 0; i < transform.childCount;i ++) {
            Debug.Log("Tag: " + transform.GetChild(i).gameObject.tag);
            if (transform.GetChild(i).gameObject.activeInHierarchy && transform.GetChild(i).gameObject.tag == "Player") {
                targetGroup.AddMember(transform.GetChild(i), 1, 0);
                Debug.Log("added player");
            }
        }
        hasInit = true;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        if (scene.name != "PlayScene")
            return;
        Debug.Log("Is play scene");
        cMCamera = GameObject.FindGameObjectWithTag("TargGroup");
        targetGroup =
        cMCamera.GetComponent<Cinemachine.CinemachineTargetGroup>();
        //cMCamera.GetComponent<Cine>
        //Debug.Log("child count: " + transform.childCount.ToString());
        isPlayscene = true;
        hasInit = false;
        Debug.Log("set has init to false");
    }

}
