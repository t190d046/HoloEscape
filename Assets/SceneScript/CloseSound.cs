using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSound : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {

    }

    public void ClosePlay(AudioClip clip){
        // 音再生
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}