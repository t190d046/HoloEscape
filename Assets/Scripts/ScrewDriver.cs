using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewDriver : MonoBehaviour
{
    Transform nowTransform;
    Vector3 prevRotation;
    Vector3 pos;
    Rigidbody rb;

    Screw screw;

    bool screwTurnFrag;

    void Start()
    {
        nowTransform = this.gameObject.transform;
        prevRotation = nowTransform.localEulerAngles;
        pos = nowTransform.position;
        rb = this.gameObject.GetComponent<Rigidbody>();

        screwTurnFrag = false;
    }

    void FixedUpdate()
    {
        Debug.Log(nowTransform.localEulerAngles.y + " - " + prevRotation.y + " = " + (nowTransform.localEulerAngles.y - prevRotation.y));
        if (!screwTurnFrag || screw == null)
        {
            rb.constraints = RigidbodyConstraints.None;
            prevRotation.y = nowTransform.localEulerAngles.y;
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
            pos.x = collision.transform.position.x;
            pos.y = collision.transform.position.y + 0.5f;
            pos.z = collision.transform.position.z;
            nowTransform.position = pos;

            Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            screw = collision.gameObject.GetComponent<Screw>();
            prevRotation.y = nowTransform.localEulerAngles.y;
            screwTurnFrag = true;
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Screw")
        {
            pos.x = collision.transform.position.x;
            pos.y = collision.transform.position.y + 0.5f;
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
