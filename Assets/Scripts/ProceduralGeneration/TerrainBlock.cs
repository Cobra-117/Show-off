using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBlock : MonoBehaviour
{
    public enum BlockType
    {
        SWIM,
        JUMP,
        FLY,
        WALK
    }

    public GameObject[] walls;
    public BlockType blockType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player") {
            if (blockType == BlockType.SWIM)
            {
                Debug.Log("entered water");
            } else if (blockType == BlockType.JUMP)
            {
                Debug.Log("entered jump");
            } else if (blockType == BlockType.FLY)
            {
                Debug.Log("entered fly");
            }
            else if (blockType == BlockType.WALK)
            {
                Debug.Log("entered walk");
            }
        }
    }

    public void RemoveWall(int direction)
    {
        string wallName;
        switch (direction)
        {
            case 0:
                wallName = "North Wall";
                break;
            case 1:
                wallName = "East Wall";
                break;
            case 2:
                wallName = "South Wall";
                break;
            case 3:
                wallName = "West Wall";
                break;
            default:
                Debug.LogWarning("Your direction can't be superior to 3. 0 = north, 1 = east, 2 = south, 3 = west");
                return;
        }
        Debug.Log("removed " + direction.ToString());
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).gameObject.name == wallName)
                transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
