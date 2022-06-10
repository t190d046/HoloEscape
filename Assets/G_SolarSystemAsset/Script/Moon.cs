using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{   
    [SerializeField] Transform room;

    public bool isCatch = false;
    public void CatchKey()
    {
        isCatch = true;
        transform.parent = room;
    }
    public void ReleaseKey()
    {
        isCatch = false;
    }
}
