using UnityEngine;

public class Example : MonoBehaviour
{
    // Frame update example: Draws a 10 meter long green line from the position for 1 frame.
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green, 30.0f);
    }
}