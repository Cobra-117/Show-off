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

    public BlockType blockType;
    public CorruptedDataWall dataWave;
    bool hasBeenUsed = false;
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
        //Debug.Log("trigged enter");
        if (other.gameObject.tag == "Player") {
            if (blockType == BlockType.SWIM)
            {
                //Debug.Log("entered water");
                /*other.gameObject.transform.parent.gameObject.
                GetComponent<SwitchMovement>().SwitchToSwimming();
                */
            } else if (blockType == BlockType.JUMP)
            {
                //Debug.Log("entered jump");
                /*other.gameObject.transform.parent.gameObject.
                GetComponent<SwitchMovement>().SwitchToJumping();
                */
            } else if (blockType == BlockType.FLY)
            {
                //Debug.Log("entered fly");
                /*other.gameObject.transform.parent.gameObject.
                GetComponent<SwitchMovement>().SwitchToFlying();
                */
            }
            else if (blockType == BlockType.WALK)
            {
                //Debug.Log("entered walk");
                /*other.gameObject.transform.parent.gameObject.
                GetComponent<SwitchMovement>().SwitchToWalking();
                */
            }
            if (hasBeenUsed == false) {
                //transform.parent.GetComponent<TerrainGenerator>().AddWater();
                if (transform.parent == null)
                    return;
                transform.parent.GetComponent<TerrainGenerator>().AddBlock(Random.Range(2, 
                transform.parent.GetComponent<TerrainGenerator>().blocks.Length));
                //generate
                hasBeenUsed = true;
                dataWave.UpdateChunk();
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                foreach (GameObject player in players)
                {
                    player.GetComponent<Walk>().UpdateChunk();
                }
                //Debug.Log("adding blocks");
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
                //Debug.LogWarning("Your direction can't be superior to 3. 0 = north, 1 = east, 2 = south, 3 = west");
                return;
        }
        //Debug.Log("removed " + direction.ToString());
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).gameObject.name == wallName)
                transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
