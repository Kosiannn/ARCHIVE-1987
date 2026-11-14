using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Command_Log : MonoBehaviour
{
    [SerializeField] private TMP_Text logText;

    [SerializeField] private int maxLines = 200;

    private readonly StringBuilder logBuffer = new StringBuilder();

    public void AddLog(string message)
    {
        string time = DateTime.Now.ToString("HH:mm:ss");
        logBuffer.AppendLine($"[{time}] {message}");

        // ログの行数を制限して、増えすぎるのを防ぐ
        string[] lines = logBuffer.ToString()
            .Split('\n');

        if (lines.Length > maxLines + 1)
        {
            logBuffer.Clear();

            int start = lines.Length - maxLines - 1;

            for (int i = start; i < lines.Length; i++)
            {
                if (!string.IsNullOrEmpty(lines[i]))
                    logBuffer.AppendLine(lines[i]);
            }
        }

        logText.text = logBuffer.ToString();
    }

    public void ClearLog()
    {
        logBuffer.Clear();
        logText.text = "";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
