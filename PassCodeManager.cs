using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassCodeManager : MonoBehaviour
{
    private GameObject passCodePanel;
    [SerializeField] GameObject[] numberButtons;
    [SerializeField] GameObject[] numberDisp = new GameObject[4]; // ディスプレイ
    [SerializeField] Button enterButton; // EnterButton

    [SerializeField] string correctString; // 正解の文字列
    

    private int numOfPush;  // 数字ボタン押下回数を管理する変数
    private Text[] numberDispText = new Text[4]; // ディスプレイのテキストコンポーネント

    // Start is called before the first frame update
    void Start()
    {
        passCodePanel = transform.parent.gameObject;
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(numOfPush >= 4)
        {
            enterButton.interactable = true;
            foreach(GameObject button in numberButtons)
            {
                button.GetComponent<Button>().interactable = false;
            }
        }
    }

    // 初期化
    void Initialize()
    {
        // 数字ボタンのプッシュ回数を 0 で初期化
        numOfPush = 0;

        foreach(GameObject button in numberButtons)
        {
            button.GetComponent<Button>().interactable = true;
        }

        // EnterButton を 無効化
        enterButton.interactable = false;

        // 各ディスプレイのテキストコンポーネントを取得
        // 表示テキストを　"-" で初期化
        for(int i = 0; i <= 3; i++)
        {
            numberDispText[i] = numberDisp[i].GetComponent<Text>();
            numberDispText[i].text = "-";
        }
    }

    // 数字ボタンが押されたときの処理 
    public void InputNumber(int number)
    {
        // ボタンが持っている数字をディスプレイの表示に反映
        numberDispText[numOfPush].text = number.ToString();
        // プッシュ回数をインクリメント
        numOfPush++;
    }

    // EnterButtonを押したときの処理
    public void OnClickEnterButton()
    {
        // ディスプレイに表示された数字を文字としてenterNumberに格納する 
        string[] enterNumber = new string[4];
        for(int i = 0; i <= 3; i++)
        {
            enterNumber[i] = numberDispText[i].text;
        }
        
        // 各文字を連結する
        string enterString = string.Join("", enterNumber);

        // 連結してできた文字列と正解の文字列と比較する 
        if(enterString == correctString)
        {
            Debug.Log("正解！！");
            // 正解なら　Unlock処理
            Unlock();
            
        }
        else
        {
            Debug.Log("ちがうよ");
            // 不正解なら初期化
            Initialize();
        }
    }

    public void OnClickClearButton()
    {
        Initialize();
    }
    
    // アンロック処理
    public void Unlock()
    {
        // ここにUnlock時のイベントを実装
        Debug.Log("例:　扉が開いた！");
    }
}
