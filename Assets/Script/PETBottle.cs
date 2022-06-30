using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PETBottle : MonoBehaviour
{
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
    }
}
