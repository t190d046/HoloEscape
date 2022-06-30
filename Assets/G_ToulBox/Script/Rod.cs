using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    public void isGrab()
    {
        FixedJoint joint = this.gameObject.GetComponent<FixedJoint>();
        Destroy(joint);
    }
}
