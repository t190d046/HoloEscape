using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveDoor: MonoBehaviour
{
    [SerializeField] Transform doorTramsform;
    public bool canMove = true;
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
        if (canMove)
        {
            if (collision.gameObject.name == "ExitDoor_Key")
            {
                canMove = false;
                StartCoroutine(DoorMoveCoroutine());
            }
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

        for (int i = 0; i < 90; i++)
        {
            yield return new WaitForSeconds(0.11f);
            if (doorTramsform.localEulerAngles.y < 0 || doorTramsform.localEulerAngles.y > - 90)
            {
                doorTramsform.Rotate(0f, angle, 0f);
            }
        }
        Debug.Log(doorTramsform.localEulerAngles);
        canMove = true;
    }

}
