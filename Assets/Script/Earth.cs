using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    void OnTriggerStay(Collider collision)
    {
        Debug.Log("Enter_" + collision.name);

        if (collision.gameObject.name == "Key")
        {
            Key key = collision.GetComponent<Key>();
            if (!key.isCatch)
            {
                key.transform.parent = this.transform;
                key.transform.localPosition = new Vector3(0.9f, 0, 0);
                key.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
    }
}
