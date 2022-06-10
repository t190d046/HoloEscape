using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class GemPlate : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject keyHole;
    private bool[] SetGemArray = new bool[] { false, false, false, false, false, false };
    private int num = 0;
    public void setGem()
    {
        if (num > 6) return;
        SetGemArray[num] = true;
        num++;
    }

    public void CheckGem()
    {
        foreach (bool gem in SetGemArray)
        {
            if (gem == false) return;

        }
        keyHole.SetActive(true);
        gameManager.SetClearDoorLock();
    }
}
