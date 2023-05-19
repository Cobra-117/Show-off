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
        AddBlock(2);
        for (int i = 0; i < 3; i++) {
            AddBlock(Random.Range(0, 4));
        }

        //Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBlock(int blockType)
    {
        Vector3 coordinates = new Vector3(nbrOfBlocks * blockSize.x,
        0, 0);

        GameObject block = GameObject.Instantiate(blocks[blockType]);
        block.transform.position = coordinates;
        block.transform.parent = this.transform;
        blocksList.Add(block);
        nbrOfBlocks += 1;
        if (blocksList.Count > simultaneousBlocks) {
            Destroy(blocksList[0]);
            blocksList.RemoveAt(0);
        }
    }


    void GenerateOld()
    {
        /*for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++) 
            {
                Vector3 coordinates = new Vector3(x * blocksize,
                0, -z*blocksize);
                GameObject block = GameObject.Instantiate(blocks[Random.Range(0, 4)]);
                block.transform.position = coordinates;
                TerrainBlock terrainBlock = block.GetComponent<TerrainBlock>();
                if (x > 0)
                    terrainBlock.RemoveWall(3);
                if (x < xSize -1)
                    terrainBlock.RemoveWall(1);
                if (z % 2 == 0) 
                {
                    if (x == xSize -1)
                        terrainBlock.RemoveWall(2);
                    if (z != 0 && x == 0)
                        terrainBlock.RemoveWall(0);
                } else {
                    if (x == 0)
                        terrainBlock.RemoveWall(2);
                    if (x == xSize -1)
                        terrainBlock.RemoveWall(0);
                }
            }
        }*/
    }
}
