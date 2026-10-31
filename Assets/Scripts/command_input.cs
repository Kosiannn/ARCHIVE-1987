using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class command_input : MonoBehaviour
{
    //InputFieldを取得するための変数
    InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        //InputFieldコンポーネントを取得
        inputField = GameObject.Find("InputCommand").GetComponent<InputField>();
    }

    public void GetInputCommand()
    {
        //InputFieldのテキストを取得
        string inputCommand = inputField.text;

        //取得したテキストをコンソールに表示
        Debug.Log(inputCommand);

        //InputFieldのテキストをクリア
        inputField.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
