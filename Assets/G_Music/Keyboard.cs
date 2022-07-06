using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] GameObject keyIten;
    [SerializeField] Renderer[] lamp;
    [SerializeField] Material mateOff, mateOn;
    private int[] pressedkey = new int[14];
    private int[] answerkey = { 0, 0, 4, 4, 5, 5, 4, 3, 3, 2, 2, 1, 1, 0 };
    static private int i = 0;

    private bool isComplete = false;
    public void PressKey(int key)
    {
        if (isComplete) return;
        
        pressedkey[i] = key;
        lamp[i].material = mateOn;
        i++;

        if (i == 14) CheckComplete();
    }

    private void CheckComplete()
    {
        int j = 0;
        foreach (var key in pressedkey)
        {
            if (key != answerkey[j])
            {
                Reset();
                return;
            }
            j++;
        }
        keyIten.SetActive(true);
        isComplete = true;
    }

    public void Reset()
    {
        foreach (var tmp in lamp)
        {
            tmp.material = mateOff;
        }
        i = 0;
    }
}
