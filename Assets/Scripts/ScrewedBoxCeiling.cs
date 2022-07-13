using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewedBoxCeiling : MonoBehaviour
{
    int remainScrewNum;

    void Start()
    {
        remainScrewNum = 4;
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Screw")
        {
            Destroy(collision.gameObject);
            remainScrewNum--;
            Debug.Log(remainScrewNum);

            if (remainScrewNum <= 0)
            {
                CanOpen();
            }
        }
    }

    void CanOpen()
    {
        FixedJoint joint = this.gameObject.GetComponent<FixedJoint>();
        Destroy(joint);
    }
}
