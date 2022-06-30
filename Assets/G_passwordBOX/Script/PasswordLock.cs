using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordLock : MonoBehaviour
{

    public GameObject[] pCube;
    public Text inputField;
    public string pass;
    public int cnt;
    public GameObject inputBox;
    public Material[] material;

    void Start()
    {
        pass = "";
        cnt = 0;
        inputField.text = "";
    }

    public void OnClickPasswordLock(Text num)
    {
        cnt++;
        if (cnt <= 4)
        {
            pass += num.text;
            inputField.text += "   " + num.text;
            inputBox.GetComponent<Renderer>().material = material[cnt];
        }
        Debug.Log(pass);
    }

    public void InputCancel()
    {
        pass = "";
        cnt = 0;
        inputField.text = "";
        inputBox.GetComponent<Renderer>().material = material[0];
        Debug.Log("Cancel");
    }

    public void InputEnter()
    {
        if (pass == "2301")
        {
            for(int i=0;i<12;i++)
            {
                Destroy(pCube[i]);
            }
            // pCube[5]のオブジェクトのサイズを 0.1f 拡大する
            //pCube[5].transform.localScale = pCube[5].transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
            inputField.text = "   C  l  e  a  r  ";
        }
        else
        {
            InputCancel();
        }
        Debug.Log("Enter");
    }
}
