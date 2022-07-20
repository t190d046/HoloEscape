using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainScene: MonoBehaviour {
 
    // Use this for initialization
    void Start () {

    }
    
    // Update is called once per frame
    void Update () {
        
    }
 
    // Destroy when Credit
    public void EndingC2Title(){
        GameObject obj = GameObject.Find("CreditPanel");
        Destroy(obj.gameObject, 5f);
        Ending2Title();
    }

    // Destroy Objects when Ending to Title sence
    public void Ending2Title(){
        GameObject obj = GameObject.Find("Ending");
        Destroy(obj.gameObject, 10f);
        ChangeScene();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}