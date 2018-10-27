using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class money_Show : MonoBehaviour {
    public Text Text;
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        //存取coin顯示金錢
        Text.text = "金錢:" + PlayerPrefs.GetInt("coin");
    }
}
