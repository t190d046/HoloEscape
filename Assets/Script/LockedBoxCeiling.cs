using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedBoxCeiling : MonoBehaviour
{
    public void Unlocked()
    {
        FixedJoint joint = this.gameObject.GetComponent<FixedJoint>();
        Destroy(joint);
    }
}
