using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCatcher : MonoBehaviour
{
    [SerializeField] Transform room;
    public void CatchObject()
    {
        if (transform.parent != room)
        {
            transform.parent = room;
        }
        Destroy(this);
    }
}
