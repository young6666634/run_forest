using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class password_Input : MonoBehaviour {
    public Text text;
    public Image Image_Bg;
    public Button bt1, bt2,bt3;
    string text_passward = "";
    // Use this for initialization
    void Start () {
        bt1.gameObject.SetActive(false);
        bt2.gameObject.SetActive(false);
        bt3.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("password_time") != 0 || PlayerPrefs.GetString("password") != "")
        {
            Image_Bg.gameObject.SetActive(false);
            bt1.gameObject.SetActive(true);
            bt2.gameObject.SetActive(true);
            bt3.gameObject.SetActive(true);
            //PlayerPrefs.DeleteAll();
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        
    }
    public void Get_password()
    {
        //只要密碼不是空
        if (text.text!="")
        {
            //設定密碼 與各種密碼相關狀態
            text_passward = text.text;
            PlayerPrefs.SetString("password", text_passward);
            PlayerPrefs.SetInt("on", 1);
            PlayerPrefs.SetInt("deleaton", 1);
            PlayerPrefs.SetInt("orign_time", 0);
            //最初設定限制時間3分鐘
            PlayerPrefs.SetInt("password_time", 180);
            Image_Bg.gameObject.SetActive(false);
            Debug.Log(PlayerPrefs.GetString("password"));
            bt1.gameObject.SetActive(true);
            bt2.gameObject.SetActive(true);
            bt3.gameObject.SetActive(true);
        }
    }
}
