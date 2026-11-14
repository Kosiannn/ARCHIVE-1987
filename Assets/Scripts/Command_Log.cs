
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Command_Log : MonoBehaviour
{
    [Header("Log Settings")]
    [SerializeField] private TMP_Text logText;

    [Header("Typewriter Settings")]
    [SerializeField] private float delay = 0.03f;

    [Header("Log Limit")]
    [SerializeField] private int maxLines = 200;

    private StringBuilder logBuffer = new StringBuilder();

    private Coroutine typingCoroutine;

    // ログを追加する
    public void AddLog(string message)
    {
        string time = System.DateTime.Now.ToString("HH:mm:ss");

        string newLog = $"[{time}] {message}";

        // 新しいログを追加
        logBuffer.AppendLine(newLog);

        // 画面に反映
        UpdateLog(newLog);
    }

    // ログを更新する
    private void UpdateLog(string newLog)
    {
        // ログの行数制限
        string[] lines = logBuffer.ToString().Split('\n');

        if (lines.Length > maxLines + 1)
        {
            int removeCount = lines.Length - maxLines - 1;

            for (int i = 0; i < removeCount; i++)
            {
                logBuffer.Remove(0, lines[i].Length + 1);
            }
        }

        // 過去のログをすべて表示状態にする
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        logText.text = logBuffer.ToString();
        logText.maxVisibleCharacters = int.MaxValue;

        // 新しいログだけ文字送り
        typingCoroutine = StartCoroutine(FlowText(newLog));
    }

    // 新しいログだけ文字送り
    private IEnumerator FlowText(string newLog)
    {
        int totalChars = logText.textInfo.characterCount;

        // 新しいログの開始位置
        int startIndex = totalChars - newLog.Length;

        for (int i = 0; i <= newLog.Length; i++)
        {
            logText.maxVisibleCharacters = startIndex + i;

            yield return new WaitForSeconds(delay);
        }

        logText.maxVisibleCharacters = int.MaxValue;

        typingCoroutine = null;
    }

    // ログを消去
    public void ClearLog()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        logBuffer.Clear();

        logText.text = "";
    }

    // 文字送りをスキップ
    public void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        logText.maxVisibleCharacters = int.MaxValue;
    }
}
