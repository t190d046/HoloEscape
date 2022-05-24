using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    [SerializeField] PlanetController[] planetList;
    [SerializeField] PlanetController solar;
    // Update is called once per frame
    void FixedUpdate()
    {
        solar.PlanetRotate();
        foreach (PlanetController planet in planetList)
        {
            planet.PlanetRevolution();
            planet.PlanetRotate();
        }
    }
}
