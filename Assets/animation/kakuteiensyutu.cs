using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakuteiensyutu : MonoBehaviour
{
    public bool frag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2) return;
        if (frag == false) return;
        transform.Translate(0, -0.01f, 0);

    }
    public void Setfrag(bool frag_a)
    {
        frag = frag_a;
    }
}
