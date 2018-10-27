using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delate : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collisiona)
    {
        if(collisiona.gameObject.tag=="chts")
        {
       
            StartCoroutine(enumerator());
            
        }
    }


    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(5);
        /* 經過刪除的功能 目前先取消
        if(PlayerPrefs.GetInt("deleaton") ==1)
        gameObject.transform.parent.gameObject.SetActive(false);
        */
    }
}
