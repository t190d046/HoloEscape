using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    bool flag = true;
    int count = 0;
    private void Update()
    {
        if (count < 1000)
        {
            count++;
            return;
        }

        if (flag == true && transform.localPosition.y > 0)
        {
            transform.Translate(0f, -0.01f, 0f);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        count = 0;
        flag = false;
        Debug.Log("Enter_" + collision.name);

    }
    void OnTriggerStay(Collider collision)
    {
        count = 0;
        Debug.Log("Stay_" + collision.name);
        if (transform.localPosition.y < 4)
        {
            if (collision.gameObject.name == "Sphere")
            {
                transform.Translate(0f, 0.01f, 0f);
            }
        }
    }
    void OnTriggerExit(Collider collision)
    {
        flag = true;
        Debug.Log("Exit_" + collision.name);
    }
}
