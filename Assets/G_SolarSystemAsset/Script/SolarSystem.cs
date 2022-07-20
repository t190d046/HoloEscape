using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    [SerializeField] PlanetController solar;
    private PlanetController[] planetList;

    private void Start()
    {
        ChildrenUpdate();
    }
    public void ChildrenUpdate()
    {
       planetList = GetComponentsInChildren<PlanetController>();
       //Debug.Log("planetList_" + planetList.Length);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (planetList == null) return;
        foreach (PlanetController planet in planetList)
        {
            planet.PlanetRevolution();
            planet.PlanetRotate();
        }
    }
}
