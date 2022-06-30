using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    public void isGrab()
    {
        FixedJoint joint = this.gameObject.GetComponent<FixedJoint>();
        Destroy(joint);
    }
}
