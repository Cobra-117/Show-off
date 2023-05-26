using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingWall : MonoBehaviour
{
    List<GameObject> walls;
    public float changeTime = 2;

   public float countdown;

    void Start()
    {
        walls = new List<GameObject>();
        //foreach GameObject wall in get
        for (int i = 0; i < transform.childCount; i++) 
        {
            walls.Add(transform.GetChild(i).gameObject);
        }
        countdown = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0) {
            countdown = changeTime;
            SwitchWalls();
        }
    }

    void SwitchWalls()
    {
        for (int i = 0; i < walls.Count; i++) {
            if (Random.Range(0, 2) == 0)
                walls[i].SetActive(true);
            else
                walls[i].SetActive(false);
        }
        /*int r1 = Random.Range(0, walls.Count);
        int r2 = r1;
        while (r1 == r2) {
            r2 = Random.Range(0, walls.Count);
        }
        walls[r1].SetActive(false);
        walls[r2].SetActive(false);*/
    }
}
