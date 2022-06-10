using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    [SerializeField] Transform room;
    private Vector3 m_localScale;
    private void Awake()
    {
        m_localScale = transform.localScale;
    }
    public void Catch()
    {
        transform.parent = room;
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Enter_" + collision.name);

        if (collision.gameObject.name == "TableFork")
        {
            transform.parent = collision.transform;
            transform.localScale = m_localScale;
        }
    }
    
}
