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
}
