using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skill : MonoBehaviour {
    //cht_pos 會經由腳色產生腳本傳遞
    public GameObject cht_pos;
    public Sprite fast, strong;
    bool fast_bool = false,strong_bool=false;
    // Use this for initialization
    void Start () {
        //如果有購買無敵技能
        if (PlayerPrefs.GetInt("strong") == 1)
        {
            //套上圖片
            gameObject.GetComponent<Image>().sprite = strong;
            strong_bool = true;
        }
        //如果沒購買無敵 但有加速技能
        else if (PlayerPrefs.GetInt("fast") == 1)
        {
            gameObject.GetComponent<Image>().sprite = fast;
            fast_bool = true;
        }
        else
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        //如果都沒有 把技能欄位調成透明
    }
	
	// Update is called once per frame
	void Update () {

  
        //按鈕維持在腳色位置的前方
        gameObject.transform.position = new Vector3(cht_pos.transform.position.x + 10f, -1f, 80f);
    }
    public void skill_Use()
    {
        //如果有加速技能 bool=true
        if (fast_bool)
        {
            //資料庫有加速技能
            if (PlayerPrefs.GetInt("fast") == 1)
            {
                //取得腳色狀態 加速
                cht_pos.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300f);
                //圖案變透明
                gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                //加速用完取消
                PlayerPrefs.SetInt("fast", 0);
                fast_bool = false;
            }

        }
        if (strong_bool)
        {
            if (PlayerPrefs.GetInt("strong") == 1)
            {
                //啟動無敵 腳色身上skill_Trigger=false才是發動 因為腳色身上條件式的關係
                cht_pos.gameObject.GetComponent<Chartmove>().skill_Trigger = false;
                //執行5秒後 將無敵關閉
                StartCoroutine(deadtrigger());
                gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                PlayerPrefs.SetInt("strong", 0);
                fast_bool = false;
            }

        }
    }
    //用來讓腳色變無敵 無敵五秒
    IEnumerator deadtrigger()
    {
        yield return new WaitForSeconds(5);
        cht_pos.gameObject.GetComponent<Chartmove>().skill_Trigger = true;
        //5秒後將skill_Trigger改回去 無敵結束
    }
}
