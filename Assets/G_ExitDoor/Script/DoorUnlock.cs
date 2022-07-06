using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] GameObject doorBoard;
    [SerializeField] TextMeshPro text;
    [SerializeField] WebApiClient webApiClient;

    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Enter_" + collision.name);

        if (collision.gameObject.name == "ExitDoor_Key")
        {
            SetUnlock();


        }
    }

    public void SetUnlock()
    {
        webApiClient.DoorLock();
        text.text = "OPEN";
        text.color = Color.green;
        doorBoard.SetActive(false);
    }
}
