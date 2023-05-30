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
        Debug.Log("trigged enter");
        if (other.gameObject.tag == "Player") {
            if (blockType == BlockType.SWIM)
            {
                Debug.Log("entered water");
                other.gameObject.transform.parent.gameObject.
                GetComponent<SwitchMovement>().SwitchToSwimming();
            } else if (blockType == BlockType.JUMP)
            {
                Debug.Log("entered jump");
                other.gameObject.transform.parent.gameObject.
                GetComponent<SwitchMovement>().SwitchToJumping();
            } else if (blockType == BlockType.FLY)
            {
                Debug.Log("entered fly");
                other.gameObject.transform.parent.gameObject.
                GetComponent<SwitchMovement>().SwitchToFlying();
            }
            else if (blockType == BlockType.WALK)
            {
                Debug.Log("entered walk");
                other.gameObject.transform.parent.gameObject.
                GetComponent<SwitchMovement>().SwitchToWalking();
            }
            if (hasBeenUsed == false) {
                transform.parent.GetComponent<TerrainGenerator>().AddBlock(Random.Range(0, 
                transform.parent.GetComponent<TerrainGenerator>().blocks.Length));
                hasBeenUsed = true;
                Debug.Log("adding blocks");
            }
        }
    }
}
