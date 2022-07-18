using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Microsoft.MixedReality.WorldLocking.Core;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Transform room;
    [SerializeField] WebApiClient webApiClient;

    private Transform camTrans;

    public bool isClearToolBox = false;
    public bool isClearPetbottle = false;
    public bool isClearDriverBox = false;
    public bool isClearIce = false;
    public bool isClearLight = false;
    public bool isClearPiano = false;
    public bool isClearInMirror = false;
    public bool isClearSlidePuzzle = false;
    public bool isClearPassword = false;
    public bool isClearDoorGem = false;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        WorldLockingManager.GetInstance().Load();
        camTrans = Camera.main.transform;
        InitGame();
        StartCoroutine(webApiClient.Login());
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
        isClearToolBox = false;
        isClearPetbottle = false;
        isClearDriverBox = false;
        isClearIce = false;
        isClearLight = false;
        isClearPiano = false;
        isClearSlidePuzzle = false;
        isClearPassword = false;
        isClearInMirror = false;
        isClearDoorGem = false;
    }

}
