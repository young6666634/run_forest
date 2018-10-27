using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shoot : MonoBehaviour {
    public GameObject cht_pos;
    public GameObject bullet;
    public AudioSource biu;
    bool isactivity;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     
        
        //按鈕維持在腳色位置的前方
        gameObject.transform.position = new Vector3(cht_pos.transform.position.x + 10f, -3f, 80f);

        
    }
     void OnMouseDown()
    {
        ///製造子彈 去抓取腳色的存活狀態 是存活下方才能運行
        isactivity = cht_pos.gameObject.GetComponent<Chartmove>().is_Activity;
        if (isactivity)
        {
            //biu是聲音 play啟動
            biu.Play();

            //將子彈生出來
            GameObject amo = Instantiate(bullet, cht_pos.transform.position, Quaternion.identity) as GameObject;
            //因為生出的子彈不會出現在canvas 所以父物件設定給canvas
            amo.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            //位置子彈會跑掉 所以將她的位置設在腳色的前方
            amo.transform.position = new Vector3(cht_pos.transform.position.x + 1f, cht_pos.transform.position.y, cht_pos.transform.position.z);
        }
       
    }
}
