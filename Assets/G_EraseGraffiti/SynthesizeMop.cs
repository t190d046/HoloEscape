using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

//��������̌��̃A�C�e���ɃA�^�b�`����B
public class SynthesizeMop : MonoBehaviour
{
    [SerializeField] GameObject another_item, result_item;
    // another_item = �����ɕK�v�Ȃ�������̃A�C�e���B
    // result_item = �������ʂ̃A�C�e���B

    //�@�ȉ����@�̌��t
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
    //�@�����܂Ŗ��@�̌��t

    string title = "�A�C�e������";
    string message = "�G�Ђƒ������������܂����H";
    //���{��ɂ������ꍇ�͔C�����I

    //�������ʂ̏�����������B�D���ɏ��������Ă�����B
    public void Synthesize()
    {
        GetComponent<ObjectManipulator>().enabled = false;
        Transform m_transform = transform;
        m_transform.parent = result_item.transform;
        m_transform.localPosition = new Vector3(0, 1, 0);
        m_transform.localRotation = Quaternion.identity;
        m_transform.localScale = new Vector3(2, 1, 1);
        Destroy(this);
    }


    void OnTriggerEnter(Collider collision)
    {
        //���̃A�C�e���Ƃ�������̃A�C�e�����ڐG������_�C�A���O���ĂԂ�B
        if (collision.gameObject == another_item)
        {
            Debug.Log("Enter_" + collision.name);
            OpenChoiceDialog();
        }
    }


    //�ȉ����@�̌��t
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
