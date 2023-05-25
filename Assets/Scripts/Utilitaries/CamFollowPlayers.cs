using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CamFollowPlayers : MonoBehaviour
{
    Vector3 velocity;
    Camera cam;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GameObject[] playersobj = GameObject.FindGameObjectsWithTag("Player");
        List<GameObject> activePlayers = new List<GameObject>();

        for (int i = 0; i < playersobj.Length; i++) {
            if (playersobj[i].activeInHierarchy)
                activePlayers.Add(playersobj[i]);
        }
        float middlePoint = GetMiddlePoint(activePlayers);
        Vector3 newPos = new Vector3(middlePoint, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position,
        newPos, ref velocity,.5f);
        ManageZoom(activePlayers);

    }

    float GetMiddlePoint(List<GameObject> activePlayers)
    {
        float middlePoint = 0;
        for (int i = 0; i < activePlayers.Count; i ++) {
            middlePoint += activePlayers[i].transform.position.x;
        }
        middlePoint = middlePoint / activePlayers.Count;
        transform.position = new Vector3(middlePoint, transform.position.y, transform.position.z);
        return middlePoint;
    }

    void ManageZoom(List<GameObject> activePlayers)
    {
        float greatestDistance = GetGreatestDistance(activePlayers);
        float newZoom = Mathf.Lerp(maxZoom, minZoom, greatestDistance /zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance(List<GameObject> activePlayers)
    {
        var bounds = new Bounds(activePlayers[0].transform.position,
        Vector3.zero);
        for (int i = 0; i < activePlayers.Count; i++) {
            bounds.Encapsulate(activePlayers[i].transform.position);
        }
        return bounds.size.x;
    }
}
