using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    GameObject lockedBoxCeiling;
    GameObject scissors;
    GameObject rod;

    void Start()
    {
        lockedBoxCeiling = GameObject.Find("LockedBoxCeiling");
        scissors = GameObject.Find("Scissors");
        rod = GameObject.Find("screwdriver_rod");
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.name == "LockedBoxKey")
        {
            lockedBoxCeiling.GetComponent<LockedBoxCeiling>().Unlocked();
            scissors.GetComponent<BoxCollider>().enabled = true;
            rod.GetComponent<BoxCollider>().enabled = true;
            gameManager.isClearToolBox = true;
        }
    }
}
