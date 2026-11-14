using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class command_input : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Command_Log commandLog;

    public void GetInputCommand()
    {
        string inputCommand = inputField.text;

        if (string.IsNullOrWhiteSpace(inputCommand))
            return;

        commandLog.AddLog("> " + inputCommand);

        inputField.text = "";
        StartCoroutine(RefocusNextFrame());
    }

    IEnumerator RefocusNextFrame()
    {
        yield return null; // 1フレーム待つ
        inputField.ActivateInputField();
    }
}