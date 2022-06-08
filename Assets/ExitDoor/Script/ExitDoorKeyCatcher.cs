using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorKeyCatcher : MonoBehaviour
{
    [SerializeField] Transform room;

    public bool isCatch = false;
    public void CatchObject()
    {
        if (transform.parent != room)
        {
            transform.parent = room;
        }
        isCatch = true;
    }
    public void ReleaseObject()
    {
        isCatch = false;
    }
}
