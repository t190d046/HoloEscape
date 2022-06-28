using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Microsoft.MixedReality.WorldLocking.Core;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Transform room;

    private Transform camTrans;

    private bool isClearPetbottle = false;
    private bool isClearIce = false;
    private bool isClearSlidePuzzle = false;
    private bool isClearPassword = false;
    private bool isClearLight = false;
    private bool isClearInMirror = false;
    private bool isClearDoorLock = false;
    public void SetClearPetbottle()
    {
        isClearPetbottle = true;
    }
    public void SetClearIce()
    {
        isClearIce = true;
    }
    public void SetClearSlidePuzzle()
    {
        isClearSlidePuzzle = true;
    }
    public void SetClearPassword()
    {
        isClearPassword = true;
    }
    public void SetClearLight()
    {
        isClearLight = true;
    }
    public void SetClearInMirror()
    {
        isClearInMirror = true;
    }
    public void SetClearDoorLock()
    {
        isClearDoorLock = true;
    }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        WorldLockingManager.GetInstance().Load();
        camTrans = Camera.main.transform;
        InitGame();
    }

    private void Update()
    {
        if(camTrans.position.z > 3)
        {
            SceneManager.LoadScene("ending");
        }
    }

    void InitGame()
    {
        isClearPetbottle = false;
        isClearIce = false;
        isClearSlidePuzzle = false;
        isClearPassword = false;
        isClearLight = false;
        isClearInMirror = false;
        isClearDoorLock = false;
    }

}
