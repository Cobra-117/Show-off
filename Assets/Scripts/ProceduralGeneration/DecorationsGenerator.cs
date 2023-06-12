using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationsGenerator : MonoBehaviour
{
    public Vector2 blockSize;
    public GameObject blockObj;
    public int simultaneousBlocks = 4;
    int nbrOfBlocks;
    List<GameObject> blocksList;

    void Start()
    {
        blocksList = new List<GameObject>();
    }

    public void AddBlock()
    {
        Vector3 coordinates = new Vector3(nbrOfBlocks * blockSize.x,
        0, 0);
        GameObject block = GameObject.Instantiate(blockObj);
        block.transform.position = coordinates;
        block.transform.parent = this.transform;
        blocksList.Add(block);
        nbrOfBlocks += 1;
        if (blocksList.Count > simultaneousBlocks) {
            Destroy(blocksList[0]);
            blocksList.RemoveAt(0);
        }
    }
}
