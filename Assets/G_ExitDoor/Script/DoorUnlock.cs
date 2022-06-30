using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] Transform doorTramsform;
    [SerializeField] WebApiClient webApiClient;
    public bool canMove = true;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Enter_" + collision.name);

        if (canMove)
        {
            if (collision.gameObject.name == "ExitDoor_Key")
            {
                canMove = false;
                StartCoroutine(DoorMoveCoroutine());
                webApiClient.DoorLock();

            }
        }
    }

    IEnumerator DoorMoveCoroutine()
    {

        for (int i = 0; i < 90; i++)
        {
            yield return new WaitForSeconds(0.11f);
            if (doorTramsform.localEulerAngles.y < 0 || doorTramsform.localEulerAngles.y > -90)
            {
                doorTramsform.Rotate(0f, -1.0f, 0f);
            }
        }
        Debug.Log(doorTramsform.localEulerAngles);
    }
}
