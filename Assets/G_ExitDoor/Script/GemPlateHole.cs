using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class GemPlateHole : MonoBehaviour
{
    [SerializeField] GemPlate gemPlate;
    void OnTriggerStay(Collider collision)
    {
        if (transform.childCount != 0) return;

        if (collision.gameObject.tag == "KeyGem")
        {
            //Debug.Log("Enter_" + collision.name);

            Transform c_transform = collision.transform;
            c_transform.parent = transform;
            collision.GetComponent<BoxCollider>().enabled = false;
            collision.GetComponent<Rigidbody>().isKinematic = true;
            collision.GetComponent<ObjectManipulator>().enabled = false;
            collision.GetComponent<NearInteractionGrabbable>().enabled = false;
            c_transform.localPosition = new Vector3(0, 0.07f, 0);
            c_transform.localEulerAngles = new Vector3(0, 0, 0);

            gemPlate.setGem();
            gemPlate.CheckGem();

        }
    }
}
