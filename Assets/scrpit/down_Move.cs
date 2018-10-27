using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class down_Move : MonoBehaviour {

    //腳色
    public GameObject cht_Bt;
    public Animator animator;
    // Use this for initialization
    void Start() {
        animator = cht_Bt.gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update() {
        //原先預定刪除資料庫資料方便觀察
        if (Input.GetKeyDown(KeyCode.D))
            PlayerPrefs.DeleteAll();
        gameObject.transform.position = new Vector3(cht_Bt.transform.position.x - 3f, -3f, 80f);
    }

     void OnMouseDown()
    {
        //按鈕 按下做滑動動作 死亡狀態關閉
        animator.SetTrigger("slide");
        cht_Bt.gameObject.GetComponent<Chartmove>().dead_Trigger=false;
    }
    private void OnMouseUp()
    {
        //放開按鈕 回歸行走動作 死亡狀態開啟
        animator.SetTrigger("move");
        cht_Bt.gameObject.GetComponent<Chartmove>().dead_Trigger=true;
    }

}
