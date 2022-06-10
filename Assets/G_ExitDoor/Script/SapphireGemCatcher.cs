using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SapphireGemCatcher : MonoBehaviour
{
    [SerializeField] Transform room;
    [SerializeField] SolarSystem solarSystem;

    public bool isCatch = false;
    public void CatchObject()
    {
        if(transform.parent != room)
        {
            transform.parent = room;
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<PlanetController>().enabled = false;
            solarSystem.ChildrenUpdate();
        }
        isCatch = true;
    }
    public void ReleaseObject()
    {
        isCatch = false;
    }

}
