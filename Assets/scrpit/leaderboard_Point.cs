using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboard_Point : MonoBehaviour {
    //分數
    public Text text1, text2, text3;
    int coin;
    //排行榜前三名
    int []rank=new int[3];
	// Use this for initialization
	void Start () {
        //先去抓取分數的資料
        rank[0] = PlayerPrefs.GetInt("rang0", 0);
        rank[1] = PlayerPrefs.GetInt("rang1", 0);
        rank[2] = PlayerPrefs.GetInt("rang2", 0);
        //目前腳色得分
        coin = PlayerPrefs.GetInt("coin", 0);
        //簡易排序 
        rank_schedule(coin, rank);
        
        //輸出分數
        text1.text = "第一名 <color=#FFD700>" + rank[0]+ "分</color>";
        text2.text = "第二名 " + rank[1]+ "分";
        text3.text = "第三名 " + rank[2]+ "分";

        //紀錄排行榜 儲存
        PlayerPrefs.SetInt("rang0", rank[0]);
        PlayerPrefs.SetInt("rang1", rank[1]);
        PlayerPrefs.SetInt("rang2", rank[2]);     
        PlayerPrefs.Save();    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //分數大於就加進去 後面依序遞減
    void rank_schedule(int point,int []rank)
    {
        
        if(point>rank[0])
        {
            rank[2] = rank[1];
            rank[1] = rank[0];
            rank[0] = point;
            return;
        }
        if (point > rank[1])
        {
            rank[2] = rank[1];
            rank[1] = point;
            return;
        }
        if (point > rank[2])
        {
            rank[2] = point;
            return;
        }

    }
}
