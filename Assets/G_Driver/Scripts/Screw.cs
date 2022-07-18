using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    Transform nowTransform;
    Vector3 pos;
    Vector3 rot;
    float initPos_y;

    void Start()
    {
        nowTransform = this.gameObject.transform;
        pos = nowTransform.position;
        rot = nowTransform.localEulerAngles;
        initPos_y = pos.y;
        //Debug.Log("initPos_y = " + initPos_y);
    }

    public void TurnScrew(float rotation_y)
    {
        rot.z += rotation_y;
        nowTransform.localEulerAngles = rot;
        if (rotation_y > 0)
        {
            pos.y += 0.01f;
        }
        nowTransform.position = pos;
    }
}
