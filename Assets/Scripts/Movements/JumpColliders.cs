using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpColliders : MonoBehaviour
{
    public enum State
    {
        GOOD,
        PERFECT
    }
    public GameObject frog;
    public State state;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "floor"
        && state == State.PERFECT)
            frog.GetComponent<Jump>().SetPerfect(true);
        else if (other.gameObject.tag == "floor"
        && state == State.GOOD)
            frog.GetComponent<Jump>().SetGood(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "floor"
        && state == State.PERFECT)
            frog.GetComponent<Jump>().SetPerfect(false);
        else if (other.gameObject.tag == "floor"
        && state == State.GOOD)
            frog.GetComponent<Jump>().SetGood(false);
    }
}
