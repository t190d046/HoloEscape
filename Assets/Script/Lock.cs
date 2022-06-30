using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    GameObject lockedBoxCeiling;

    void Start()
    {
        lockedBoxCeiling = GameObject.Find("LockedBoxCeiling");
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.name == "LockedBoxKey")
        {
            lockedBoxCeiling.GetComponent<LockedBoxCeiling>().Unlocked();
        }
    }
}
