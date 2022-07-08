using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLock : MonoBehaviour
{
    [SerializeField] GameObject key;
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject == key)
        {
            //Debug.Log("Enter_" + collision.name);

            GetComponent<Animation>().Play();
            Destroy(this);
        }
    }
}
