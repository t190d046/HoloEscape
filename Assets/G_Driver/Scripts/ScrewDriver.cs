using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class ScrewDriver : MonoBehaviour
{
    Transform nowTransform;
    Vector3 prevRotation;
    Vector3 pos;
    Quaternion rot;
    Rigidbody rb;

    Screw screw;

    bool screwTurnFrag;

    void Start()
    {
        nowTransform = this.gameObject.transform;
        prevRotation = nowTransform.localEulerAngles;
        pos = nowTransform.position;
        rot = nowTransform.rotation;
        rb = this.gameObject.GetComponent<Rigidbody>();

        screwTurnFrag = false;
    }

    void FixedUpdate()
    {
        //Debug.Log(nowTransform.localEulerAngles.y + " - " + prevRotation.y + " = " + (nowTransform.localEulerAngles.y - prevRotation.y));
        if (!screwTurnFrag || screw == null)
        {
            prevRotation.y = nowTransform.localEulerAngles.y;
            rb.constraints = RigidbodyConstraints.None;
            GetComponent<ObjectManipulator>().EnableConstraints = false;
            return;
        }

        screwTurnFrag = false;
        float rotation_y = nowTransform.localEulerAngles.y - prevRotation.y;

        if (rotation_y != 0)
        {
            //Debug.Log(nowTransform.localEulerAngles.y + " - " + prevRotation.y + " = " + rotation_y);
            prevRotation.y = nowTransform.localEulerAngles.y;
            screw.TurnScrew(rotation_y);
        }
        screwTurnFrag = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Screw")
        {
            screw = collision.gameObject.GetComponent<Screw>();
            Quaternion s_rot = screw.transform.rotation;
            nowTransform.rotation = Quaternion.Euler(s_rot.x, s_rot.y, s_rot.z - 90);

            pos.x = collision.transform.position.x;
            pos.y = collision.transform.position.y + 0.32f;
            pos.z = collision.transform.position.z;
            nowTransform.position = pos;

            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            GetComponent<ObjectManipulator>().EnableConstraints = true;

            prevRotation.y = nowTransform.localEulerAngles.y;
            screwTurnFrag = true;
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Screw")
        {
            pos.x = collision.transform.position.x;
            pos.y = collision.transform.position.y + 0.32f;
            pos.z = collision.transform.position.z;
            nowTransform.position = pos;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Screw")
        {
            screwTurnFrag = false;
            screw = null;
        }
    }
}
