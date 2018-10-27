using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //當物件碰撞到tag名為子彈 自己消失
        if (collision.gameObject.tag == "bullet")
            gameObject.SetActive(false);
    }
}
