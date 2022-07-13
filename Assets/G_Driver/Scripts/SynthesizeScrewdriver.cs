using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

//合成するの元のアイテムにアタッチする。
public class SynthesizeScrewdriver : MonoBehaviour
{
    [SerializeField] GameObject another_item, result_item;
    // another_item = 合成に必要なもう一方のアイテム。
    // result_item = 合成結果のアイテム。

    //　以下魔法の言葉
    [SerializeField]
    [Tooltip("Assign DialogSmall_jp_192x96.prefab")]
    private GameObject dialogPrefabSmall;

    /// <summary>
    /// Small Dialog example prefab to display
    /// </summary>
    public GameObject DialogPrefabSmall
    {
        get => dialogPrefabSmall;
        set => dialogPrefabSmall = value;
    }
    //　ここまで魔法の言葉

    string title = "アイテム合成";         //ダイアログのタイトルだよ。
    string message = "○○と××を合成しますか？";     //ダイアログの本文だよ。

    //合成結果の処理を書くよ。好きに書き換えていいよ。
    public void Synthesize()
    {
        another_item.SetActive(false);
        result_item.transform.position = this.transform.position;
        result_item.transform.rotation = this.transform.rotation;
        this.gameObject.SetActive(false);
        result_item.SetActive(true);
    }


    void OnTriggerEnter(Collider collision)
    {
        //このアイテムともう一方のアイテムが接触したらダイアログを呼ぶよ。
        if (collision.gameObject == another_item)
        {
            Debug.Log("Enter_" + collision.name);
            OpenChoiceDialog();
        }
    }


    //以下魔法の言葉
    public void OpenChoiceDialog()
    {
        Dialog myDialog = Dialog.Open(DialogPrefabSmall, DialogButtonType.Yes | DialogButtonType.No, title, message, true);
        if (myDialog != null)
        {
            myDialog.OnClosed += OnClosedDialogEvent;
        }
    }
    private void OnClosedDialogEvent(DialogResult obj)
    {
        if (obj.Result == DialogButtonType.Yes)
        {
            Debug.Log(obj.Result);
            Synthesize();
        }
    }
}
