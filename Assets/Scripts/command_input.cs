using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class command_input : MonoBehaviour
{
    //TMP_InputFieldを取得するための変数
    TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        //TMP_InputFieldコンポーネントを取得
        inputField = GameObject.Find("InputCommand").GetComponent<TMP_InputField>();
    }

    public void GetInputCommand()
    {
        //TMP_InputFieldのテキストを取得
        string inputCommand = inputField.text;

        //取得したテキストをコンソールに表示
        Debug.Log(inputCommand);

        //TMP_InputFieldのテキストをクリア
        inputField.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
