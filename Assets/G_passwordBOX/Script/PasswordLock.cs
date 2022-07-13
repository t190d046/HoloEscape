using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordLock : MonoBehaviour
{
    [SerializeField] GameObject key;
    public GameObject[] pCube;
    public Text inputField;
    public string pass;
    public int cnt;
    public GameObject inputBox;
    public Material[] material;
    [SerializeField] AudioClip sound;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pass = "";
        cnt = 0;
        inputField.text = "";
    }

    public void OnClickPasswordLock(Text num)
    {
        cnt++;
        if (cnt <= 4)
        {
            audioSource.PlayOneShot(sound);
            pass += num.text;
            inputField.text += "   " + num.text;
            inputBox.GetComponent<Renderer>().material = material[cnt];
        }
        Debug.Log(pass);
    }

    public void InputCancel()
    {
        audioSource.PlayOneShot(sound);
        pass = "";
        cnt = 0;
        inputField.text = "";
        inputBox.GetComponent<Renderer>().material = material[0];
        Debug.Log("Cancel");
    }

    public void InputEnter()
    {
        audioSource.PlayOneShot(sound);
        if (pass == "2301")
        {
            key.SetActive(true);
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
