using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cht_Produce : MonoBehaviour {
    public GameObject cht_pr;
    Vector3 cht_Position;
    public GameObject panel;
    public GameObject bt,bt2,bt3,bt4;

    
    // Use this for initialization
    void Start () {
        //腳色生成位置
        cht_Position = new Vector3(-856, cht_pr.transform.position.y);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void click()
    {
        //製造出新腳色
        GameObject cht= Instantiate(cht_pr, cht_Position, Quaternion.identity)as GameObject;
        //因為新製造出的物件並不會出現在Canvas裡 所以特別將canvas設成父物件
        cht.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        //將腳色的物件 傳送到按鈕物件上 
        bt.gameObject.GetComponent<down_Move>().cht_Bt= cht;
        bt3.gameObject.GetComponent<shoot>().cht_pos = cht;
        bt4.gameObject.GetComponent<skill>().cht_pos = cht;
        bt.gameObject.SetActive(true);
        bt2.gameObject.SetActive(true);
        bt3.gameObject.SetActive(true);
        bt4.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        panel.SetActive(false);
    }
    
}
