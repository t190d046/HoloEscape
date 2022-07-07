using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip clearSound, falseSound;
    [SerializeField] GameObject keyIten, hint, musicSwitch;
    [SerializeField] Animation box;
    [SerializeField] Renderer[] lamp;
    [SerializeField] Material mateOff, mateOn;
    private int[] pressedkey = new int[14];
    private int[] answerkey = { 0, 0, 4, 4, 5, 5, 4, 3, 3, 2, 2, 1, 1, 0 };
    static private int i = 0;

    private bool isComplete = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PressKey(int key)
    {
        if (isComplete) return;
        
        pressedkey[i] = key;
        lamp[i].material = mateOn;
        i++;

        if (i == 14) CheckComplete();
    }
    public void Reset()
    {
        foreach (var tmp in lamp)
        {
            tmp.material = mateOff;
        }
        i = 0;
    }

    private void CheckComplete()
    {
        int j = 0;
        foreach (var key in pressedkey)
        {
            if (key != answerkey[j])
            {
                audioSource.PlayOneShot(falseSound);
                Reset();
                return;
            }
            j++;
        }
        Clear();
    }
    void Clear()
    {
        audioSource.PlayOneShot(clearSound);
        box.Play();
        keyIten.SetActive(true);
        hint.SetActive(true);
        musicSwitch.SetActive(false);
        isComplete = true;
    }


}
