using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PETBottle : MonoBehaviour
{
    GameObject grip;
    void Start()
    {
        grip = GameObject.Find("screwdriver_grip");
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Scissors")
        {
            CutPETBottle();
        }
    }

    void CutPETBottle()
    {
        FixedJoint joint = this.gameObject.GetComponent<FixedJoint>();
        Destroy(joint);

        GetComponent<Rigidbody>().isKinematic = true;
        grip.GetComponent<BoxCollider>().enabled = true;
    }
}
