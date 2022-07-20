using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHints : MonoBehaviour
{
    private static int hintsNumber;

    // 表示させたい画像を配列として取り込む
    [SerializeField] private GameObject[] figures = null;
    [SerializeField] private GameObject[] fig_clear = null;
    [SerializeField] private GameObject gameManeger = null;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        hintsNumber = 1;
        figures[0].SetActive(true);
        manager = gameManeger.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // hintsNumberの値を1増やす
    public void InclimentHintsNumber() {
        if(hintsNumber < 8) {
            hintsNumber += 1;
        }
    }

    // hintsNumberの値に応じて動作を行う
    public void SetActiveHints(bool x){
        int i;

        for(i = 0; i < hintsNumber; i++) {
            figures[i].SetActive(x);
        }
    }

    public void SetActiveClear(){
        if (manager.isClearToolBox){
            fig_clear[1].SetActive(true);
        }
        if (manager.isClearPetbottle){
            fig_clear[2].SetActive(true);
        }
        if (manager.isClearIce){
            fig_clear[3].SetActive(true);
        }
        if (manager.isClearSlidePuzzle){
            fig_clear[4].SetActive(true);
        }
        if (manager.isClearPiano){
            fig_clear[5].SetActive(true);
        }
        if (manager.isClearPassword){
            fig_clear[6].SetActive(true);
        }
        if (manager.isClearDoorGem){
            fig_clear[7].SetActive(true);
        }
    }

}
