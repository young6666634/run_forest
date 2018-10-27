using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public Rigidbody2D Rigidbody2D;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        //子彈速度x正向20
        Rigidbody2D.velocity = new Vector2(20, 0);
        //啟動程序
        StartCoroutine(wait_destroy());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //當觸碰到enemy或floor 摧毀自己
        if (collision.gameObject.tag == "enemy"||collision.gameObject.tag=="floor")
            Destroy(gameObject);
    }
    //過兩秒摧毀自己 因為是子彈
    IEnumerator wait_destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
