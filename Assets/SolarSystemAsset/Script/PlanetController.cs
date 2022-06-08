using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public float OrbitalPeriod;
    public float RotationPeriod;

    private Transform m_transform, p_transform;
    private Quaternion m_CurrentRotation;

    float speed = 0.5f;
    float rotY;
    float revY;

    // Use this for initialization
    void Awake()
    {
        m_transform = transform;
        p_transform = transform.parent;
        m_CurrentRotation = m_transform.localRotation;
    }
    public void setParent()
    {
        p_transform = transform.parent;
    }

    private void Start()
    {
        rotY = Time.deltaTime * speed * 36 / RotationPeriod;
        revY = Time.deltaTime * speed * 36 * OrbitalPeriod;
    }

    public void PlanetRotate()
    {
        m_transform.Rotate(0, rotY, 0);
        m_CurrentRotation = m_transform.localRotation;
    }

    public void PlanetRevolution()
    {
        Quaternion addRev = Quaternion.Euler(0, revY, 0);
        Quaternion currentRev = p_transform.localRotation;
        p_transform.localRotation = currentRev * addRev;
        m_transform.localRotation = Quaternion.Inverse(addRev) * m_CurrentRotation;
        m_CurrentRotation = m_transform.localRotation;
    }
}
