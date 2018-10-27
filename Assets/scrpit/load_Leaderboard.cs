using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class load_Leaderboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //跳場景 排行榜 與跑酷遊戲
    public void loadsenceboard()
    {
        SceneManager.LoadScene("leaderboard");
    }
    public void loadsencegame()
    {
        SceneManager.LoadScene("animal_Coin");
    }
    public void load_Password_Control()
    {
        SceneManager.LoadScene("passward");
    }
    public void load_Skill_Shop()
    {
        SceneManager.LoadScene("store");
    }
    public void Leave()
    {
        //暫定離開就刪除資料 方便測試
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
