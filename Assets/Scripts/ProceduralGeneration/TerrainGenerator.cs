using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public float xSize;
    public float zSize;
    public float blocksize;
    public GameObject[] blocks;
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {
        for (int z = 0; z < zSize; z++)
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
        }
    }
}
