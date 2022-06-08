using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPole : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Enter_" + collision.name);

        if (collision.gameObject.name == "ExitDoor_Key")
        {
            ExitDoorKeyCatcher key = collision.GetComponent<ExitDoorKeyCatcher>();
            if (!key.isCatch)
            {
                collision.transform.parent = transform;
                collision.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
}
