using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Vector2 blockSize;
    public GameObject[] blocks;
    public int simultaneousBlocks = 7;

    int nbrOfBlocks;
    List<GameObject> blocksList;
    // Start is called before the first frame update
    void Start()
    {
        blocksList = new List<GameObject>();
        Random.InitState(System.DateTime.Now.Millisecond);
        AddBlock(0);
        for (int i = 0; i < 3; i++) {
            AddBlock(Random.Range(0, blocks.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBlock(int blockType)
    {
        Vector3 coordinates = new Vector3(nbrOfBlocks * blockSize.x,
        0, 0);
        Debug.Log("will add block of type" + blockType.ToString());
        GameObject block = GameObject.Instantiate(blocks[blockType]);
        block.transform.position = coordinates;
        block.transform.parent = this.transform;
        blocksList.Add(block);
        nbrOfBlocks += 1;
        /*If max number of blocks reached: we remove the oldest ones*/
        if (blocksList.Count > simultaneousBlocks) {
            Destroy(blocksList[0]);
            blocksList.RemoveAt(0);
        }
    }
}
