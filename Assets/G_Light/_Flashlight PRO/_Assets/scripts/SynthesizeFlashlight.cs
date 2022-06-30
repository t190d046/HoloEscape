using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

//合成するの元のアイテムにアタッチする。
public class SynthesizeFlashlight : MonoBehaviour
{
    [SerializeField] GameObject another_item, result_item;
    // another_item = 合成に必要なもう一方のアイテム。
    // result_item = 合成結果のアイテム。

    //　以下魔法の言葉
    [SerializeField]
    [Tooltip("Assign DialogSmall_jp_192x96.prefab")]
    private GameObject dialogPrefabSmall;

    private Dialog myDialog = null;

    /// <summary>
    /// Small Dialog example prefab to display
    /// </summary>
    public GameObject DialogPrefabSmall
    {
        get => dialogPrefabSmall;
        set => dialogPrefabSmall = value;
    }
    //　ここまで魔法の言葉

    string title = "アイテム合成";
    string message = "懐中電灯に電池を使用しますか？";
    //日本語にしたい場合は任せた！

    //合成結果の処理を書くよ。好きに書き換えていいよ。
    public void Synthesize()
    {
        Destroy(another_item);
        result_item.GetComponent<Flashlight_PRO>().is_battery = true;
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
        if (myDialog != null) return;

        myDialog = Dialog.Open(DialogPrefabSmall, DialogButtonType.Yes | DialogButtonType.No, title, message, true);
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
