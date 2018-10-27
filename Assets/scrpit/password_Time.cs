using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class password_Time : MonoBehaviour {
    public Text text_password,text_show,text_time;
    public InputField new_time,new_password;
    int time;
    bool passowrd_correct = false;
    // Use this for initialization
    void Start () {
        new_time.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Password_Time()
    {
        if (passowrd_correct)
        {
            if (text_time.text != "")
            {
                time = int.Parse(text_time.text);
                PlayerPrefs.SetInt("password_time", time);
         
                Debug.Log(PlayerPrefs.GetInt("password_time"));
                text_show.text = "已輸入 等候三秒";
                StartCoroutine(enumerator());
            }
            if (text_password.text != "")
            {
                
                PlayerPrefs.SetString("password", text_password.text);
                
                Debug.Log(PlayerPrefs.GetString("password", text_password.text));
                text_show.text = "已輸入 等候三秒";
                StartCoroutine(enumerator());
            }
        }
        else
        {
            if (text_password.text != PlayerPrefs.GetString("password"))
                text_show.text = "請輸入正確密碼";
            else
            {
                
                new_time.gameObject.SetActive(true);
                passowrd_correct = true;
                text_show.text = "第一行:密碼驗證時間\n第二行:輸入新密碼\n擇一輸入即可";
                new_password.text = "";
                //time = int.Parse(text_password.text);
                //PlayerPrefs.SetInt("password_time", time);
                //SceneManager.LoadScene("first");
                //Debug.Log(PlayerPrefs.GetInt("password_time"));
            }
        }
    }
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("first");
    }

}
