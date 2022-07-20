using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;

public class GemPlate : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject keyHole;
    [SerializeField] SpeechInputHandler doorBoard;
    [SerializeField] TextMeshPro text;
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
        text.text = "Say\nKey\nWard";
        text.fontSize = 4;
        text.color = Color.blue;
        doorBoard.enabled = true;
        //keyHole.SetActive(true);
        gameManager.isClearDoorGem = true;
    }
}
