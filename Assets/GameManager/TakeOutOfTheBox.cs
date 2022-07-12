using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOutOfTheBox : MonoBehaviour
{
    [SerializeField] Transform room;

    public void CatchObject()
    {
        if (transform.parent != room)
        {
            transform.parent = room;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
