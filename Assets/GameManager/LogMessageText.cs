using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// �K�{�R���|�[�l���g���w��
[RequireComponent(typeof(TextMeshPro))]
public class LogMessageText : MonoBehaviour
{
    /// �f�o�b�O���O�p�e�L�X�g
    /// </summary>
    private TextMeshPro p_Text;

    /// <summary>
    /// �\���s��
    /// </summary>
    [SerializeField, Tooltip("�\���s��")]
    private int p_LineNum = 30;

    private string[] linecodes = new string[] { "\n", "\r", "\r\n" };

    /// <summary>
    /// �������֐�
    /// </summary>
    private void Awake()
    {
        // Log���b�Z�[�W�C�x���g�ǉ�
        Application.logMessageReceived += LogMessageOutput;

        p_Text = this.GetComponent<TextMeshPro>();
    }

    /// <summary>
    /// Log���b�Z�[�W�C�x���g����
    /// </summary>
    private void LogMessageOutput(string condition, string stackTrace, LogType type)
    {
        switch (type)
        {
            case LogType.Error:
                // ���O���b�Z�[�W�ƃX�^�b�N�g���[�X��\��
                ShowMessage(p_Text.text, condition, stackTrace);
                break;
            case LogType.Assert:
                // ���O���b�Z�[�W�ƃX�^�b�N�g���[�X��\��
                ShowMessage(p_Text.text, condition, stackTrace);
                break;
            case LogType.Warning:
                // ���O���b�Z�[�W�̂ݕ\��
                ShowMessage(p_Text.text, condition, "");
                break;
            case LogType.Log:
                // ���O���b�Z�[�W��\��
                ShowMessage(p_Text.text, condition, "");
                break;
            case LogType.Exception:
                break;
        }
    }

    /// <summary>
    /// �w��s���ł̃��b�Z�[�W�\������
    /// </summary>
    private void ShowMessage(string basetext, string message, string stacktrace)
    {
        string[] baselines = basetext.Split(linecodes, System.StringSplitOptions.RemoveEmptyEntries);
        string[] messagelines = message.Split(linecodes, System.StringSplitOptions.RemoveEmptyEntries);
        string[] tracelines = stacktrace.Split(linecodes, System.StringSplitOptions.RemoveEmptyEntries);

        List<string> lines = new List<string>();
        lines.AddRange(baselines);
        lines.AddRange(messagelines);
        foreach (string trace in tracelines)
        {
            lines.Add(" " + trace);
        }

        int linecount = 0;
        string textmessage = "";
        if (lines.Count > p_LineNum)
        {
            linecount = lines.Count - p_LineNum;
        }
        for (int num = linecount; num < lines.Count; num++)
        {
            if (lines[num].Length > 0)
            {
                textmessage += lines[num] + linecodes[0];
            }
        }

        p_Text.text = textmessage;
    }
}