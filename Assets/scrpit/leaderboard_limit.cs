using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class leaderboard_limit : MonoBehaviour {
    public Button Button2,Button3,Button4;
    public Text Text1,Text2,Text3;
   int cht2_limit=50, cht3_limit=100,cht4_limit=150;
	// Use this for initialization
	void Start () {
        //分數限制去取得排行榜的分數 有超過就依序解開腳色
        if ((PlayerPrefs.GetInt("rang0")) > cht2_limit || (PlayerPrefs.GetInt("rang1")) > cht2_limit || (PlayerPrefs.GetInt("rang2")) > cht2_limit)
        {
            Button2.interactable = true;
            Text1.text = "開始遊戲";
        }
        if ((PlayerPrefs.GetInt("rang0")) > cht3_limit || (PlayerPrefs.GetInt("rang1")) > cht3_limit || (PlayerPrefs.GetInt("rang2")) > cht3_limit)
        {
            Button3.interactable = true;
            Text2.text = "開始遊戲";
        }
        if ((PlayerPrefs.GetInt("rang0")) > cht4_limit || (PlayerPrefs.GetInt("rang1")) > cht4_limit || (PlayerPrefs.GetInt("rang2")) > cht4_limit)
        {
            Button4.interactable = true;
            Text3.text = "開始遊戲";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
