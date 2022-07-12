using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLock : MonoBehaviour
{
    [SerializeField] GameObject key;
    [SerializeField] Animation open;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == key)
        {
            //Debug.Log("Enter_" + collision.name);

            open.Play();
            Destroy(this);
        }
    }
}
