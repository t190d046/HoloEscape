using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolutionRing : MonoBehaviour
{
    [SerializeField] SolarSystem solarSystem;
    [SerializeField] Transform parentRevolution;
    [SerializeField] float distance;
    [SerializeField] float angle;

    void OnTriggerStay(Collider collision)
    {
        if (parentRevolution.childCount != 0) return;

        if (collision.gameObject.name == "Earth")
        {
            EarthCatcher eartht = collision.GetComponent<EarthCatcher>();
            if (!eartht.isCatch)
            {
                //Debug.Log("Enter_" + collision.name);
                eartht.SetManipuleator(false);

                Transform pL_transform = collision.transform;
                pL_transform.parent = parentRevolution;
                pL_transform.localPosition = new Vector3(distance, 0, 0);
                pL_transform.localEulerAngles = new Vector3(0, 0, angle);
                collision.GetComponent<PlanetController>().setParent();
                solarSystem.ChildrenUpdate();

            }
        }
    }

}
