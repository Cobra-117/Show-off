using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Vector2 blockSize;
    public GameObject[] blocks;
    public GameObject Water;
    public DecorationsGenerator decorationGenerator;
    public int simultaneousBlocks = 7;
    public CorruptedDataWall dataWave;

    int nbrOfBlocks;
    List<GameObject> blocksList;
    List<GameObject> waterList;
    bool shouldAddDecoration  = true;
    // Start is called before the first frame update
    void Start()
    {
        blocksList = new List<GameObject>();
        waterList = new List<GameObject>();
        Random.InitState(System.DateTime.Now.Millisecond);
        decorationGenerator.AddBlock();
        //AddWater();
        AddBlock(0, false);
        AddBlock(1, false);
        //AddBlock(Random.Range(2, blocks.Length));
        /*for (int i = 0; i < 3; i++) {
            //AddWater();
            AddBlock(Random.Range(2, blocks.Length));
        }*/

        //Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBlock(int blockType, bool randomRotation = true)
    {
        if (nbrOfBlocks %2 != 0)
            decorationGenerator.AddBlock();
        Vector3 coordinates = new Vector3(nbrOfBlocks * blockSize.x,
        0, 0);
        //Debug.Log("will add block of type" + blockType.ToString());
        GameObject block = GameObject.Instantiate(blocks[blockType]);
        block.transform.position = coordinates;
        block.transform.parent = this.transform;
        if (randomRotation == true && Random.Range(0, 2) == 0)
            block.transform.eulerAngles=  new Vector3(0, -90, 0);
        block.GetComponent<TerrainBlock>().dataWave = dataWave;
        blocksList.Add(block);
        nbrOfBlocks += 1;
        if (blocksList.Count > simultaneousBlocks) {
            Destroy(blocksList[0]);
            blocksList.RemoveAt(0);
        }
    }

    public void AddWater()
    {
        return;
        Vector3 coordinates = new Vector3(nbrOfBlocks * blockSize.x,
        0, 0);
        GameObject water = GameObject.Instantiate(Water);
        water.transform.position = coordinates;
        water.transform.parent = this.transform;
        waterList.Add(water);
        //nbrOfBlocks += 1;
        if (blocksList.Count > simultaneousBlocks) {
            Destroy(waterList[0]);
            waterList.RemoveAt(0);
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
