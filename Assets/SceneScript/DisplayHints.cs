using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHints : MonoBehaviour
{
    private static int hintsNumber = 0;

    // 表示させたい画像を配列として取り込む
    [SerializeField] private GameObject[] figures = null;

    // Start is called before the first frame update
    void Start()
    {
        
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

}
