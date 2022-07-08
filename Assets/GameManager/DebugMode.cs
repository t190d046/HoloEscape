using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    [SerializeField] GameObject mapping;
    [SerializeField] GameObject debugLog;
    [SerializeField] BoxCollider[] spacePin;
    public void SetDebugMode()
    {
        mapping.SetActive(true);
        debugLog.SetActive(true);
        foreach (var pin in spacePin)
        {
            pin.enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void SetPlayMode()
    {
        mapping.SetActive(false);
        debugLog.SetActive(false);
        foreach (var pin in spacePin)
        {
            pin.enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
