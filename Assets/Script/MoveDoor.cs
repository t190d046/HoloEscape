using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveDoor: MonoBehaviour
{
    [SerializeField] Transform doorTramsform;
    bool canMove = true;
    bool isClose = true;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Enter_" + collision.name);

        if (doorTramsform.localEulerAngles.y < 45)
        {
            isClose = true;
        }
        else
        {
            isClose = false;
        }
        Debug.Log(isClose);
        if (canMove && collision.gameObject.name == "Key")
        {
            canMove = false;
            StartCoroutine(DoorMoveCoroutine());
        }
    }
    IEnumerator DoorMoveCoroutine()
    {
        float angle;
        if (isClose)
        {
            angle = -1.0f;
        }
        else
        {
            angle = 1.0f;
        }

        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 90; i++)
        {
            if (doorTramsform.localEulerAngles.y < 0 || doorTramsform.localEulerAngles.y > - 90)
            {
                doorTramsform.Rotate(0f, angle, 0f);
            }
        }
        Debug.Log(doorTramsform.localEulerAngles);
        canMove = true;
    }

    /*
    void OnTriggerStay(Collider collision)
    {
        Debug.Log("Stay_" + collision.name);
        if (!isOpen && doorTramsform.rotation.y < 90)
        {
            if (collision.gameObject.name == "Sphere")
            {
                doorTramsform.Rotate(0f, 1f, 0f);
            }
        }

        if (isOpen && doorTramsform.rotation.y > 0)
        {
            if (collision.gameObject.name == "Sphere")
            {
                doorTramsform.Rotate(0f, -1f, 0f);
            }
        }
    }
    void OnTriggerExit(Collider collision)
    {
        flag = true;
        if (doorTramsform.rotation.y < 45)
        {
            isOpen = false;
        }
        else
        {
            isOpen = true;
        }
        Debug.Log("Exit_" + collision.name);
    }
    */
}
