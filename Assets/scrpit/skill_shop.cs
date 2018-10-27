using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skill_shop : MonoBehaviour {
    int money;
    public Text fast_text, strong_text;
	// Use this for initialization
	void Start () {
        //存取錢
        money = PlayerPrefs.GetInt("coin");

       
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("fast") == 1)
            fast_text.text = "加速已購買";
        if (PlayerPrefs.GetInt("strong") == 1)
            strong_text.text = "無敵已購買";
    }
    //買快速技能
    public void fast()
    {
       // 錢如果超過100元
        if (money >= 100)
        {
            //尚未購買
            if (PlayerPrefs.GetInt("fast") == 0)
            {
                //購買 錢-100 在存取新的錢
                PlayerPrefs.SetInt("fast", 1);
                money -= 100;
                PlayerPrefs.SetInt("coin", money);
               
            }
        }
    }
    //買無敵技能
    public void strong()
    {
       
        if (money >= 200)
        {
            //尚未購買
            if (PlayerPrefs.GetInt("strong") == 0)
            {
                PlayerPrefs.SetInt("strong", 1);
                money -= 200;
                PlayerPrefs.SetInt("coin", money);
                
            }
        }
    }
   
}
