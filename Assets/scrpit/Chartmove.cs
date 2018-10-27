using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Chartmove : MonoBehaviour
{
    public Rigidbody2D Chart_Rigidbody;
    float upforce = 10f,addforce=8f;
    public Animator animator;
    public bool is_Activity=true,dead_Trigger=true,skill_Trigger=true;
    AudioSource coin_Voice;
    Text coin_Text;
    int coin_Count=0;
    static int sence_count=2;    
    public int coin_Point;
    int random,locktime;
    public Button cht_go;
    public GameObject cht_pr;
    public GameObject infinte_sence,fast_sence,whitespace,slide_sence;
    Camera Main_Camera;
    Vector3 cht_Position=new Vector3(-846,-459);
    Transform Cht_transform;
    float maxspped=14f,speedx,speedy;
    Transform panel_transform;
    Text Text_passward;


    float time_f;
    int time_i;
    Image image_time;
    Button right,up;
    
    Collision2D Collision2D_Jump;
    GameObject obj;
    static bool ground,slide_activity;
    //碰撞      
    void OnCollisionStay2D(Collision2D collisiona)
    {
       //存活狀態 接觸到地板 設為true
        if (is_Activity)
        {           
            if (collisiona.gameObject.tag == "floor")
            {
               ground = true;                       
            }
            
            
            up.onClick.AddListener(delegate () 
            {
                //地板true 點擊上按鈕 跳
                if (ground)
                {
                    Chart_Rigidbody.velocity = new Vector2(Chart_Rigidbody.velocity.x, upforce);
                    }
            }
            );

             
        }
        
    }
    //碰撞
    void OnTriggerEnter2D(Collider2D collision)
    {
        //吃到硬幣得分 將物件消失
        if (collision.gameObject.tag == "coin")
        {
            coin_Count=coin_Count+10;
            collision.gameObject.SetActive(false);
            //音效
            coin_Voice.Play();
            coin_Point = coin_Count;
            //存取分數
            PlayerPrefs.SetInt("coin", coin_Point);
        }
        //草莓 加速
        if (collision.gameObject.tag == "strawberry")
        {
            maxspped = 60f;
            coin_Count =coin_Count+30;
            collision.gameObject.SetActive(false);
            coin_Voice.Play();
            coin_Point = coin_Count;
            //加速
            Chart_Rigidbody.AddForce(Vector2.right * 300f);
            //存取分數
            PlayerPrefs.SetInt("coin", coin_Point);
            //執行程序 等待三秒 將最大速度改回原樣
            StartCoroutine(maxspeed_Wait());
        }
    }
    //死亡 碰到空氣牆tag dead 變死亡狀態 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dead" && (dead_Trigger&&skill_Trigger))
        {
            Chart_Rigidbody.velocity = new Vector2(0, 0);
            is_Activity = false;
            //執行程序 等待三秒 在到排行版版面
            StartCoroutine(time_Wait());
            animator.SetTrigger("dead");
            // Main_Camera.transform.position = panel_transform.position;      

        }
        if (collision.gameObject.tag == "fall" )
        {
            Chart_Rigidbody.velocity = new Vector2(0, 0);
            is_Activity = false;
            //執行程序 等待三秒 在到排行版版面
            StartCoroutine(time_Wait());
            animator.SetTrigger("dead");
            // Main_Camera.transform.position = panel_transform.position;      

        }
        //碰到敵人
        if (collision.gameObject.tag == "enemy"&& skill_Trigger)
        {
            Chart_Rigidbody.velocity = new Vector2(0, 0);
            is_Activity = false;
            //執行程序 等待三秒 在到排行版版面
            StartCoroutine(time_Wait());
            animator.SetTrigger("dead");
            // Main_Camera.transform.position = panel_transform.position;      

        }

    }


    //碰觸 製造新場景
    private void OnTriggerExit2D(Collider2D collision)
    {
        //如果觸碰空氣牆
        if (collision.gameObject.tag == "wall")
        {
            //0~3隨機跳一個數字
            random = Random.Range(0, 4);
            //場景位置
            Vector3 pos = new Vector3(sence_count * 1910, 0, 0);
            //4個場景隨機跳一個
            if (random == 0)
            {
                GameObject sence = Instantiate(infinte_sence, pos, Quaternion.identity) as GameObject;
                sence.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                sence_count++;
            };
            if (random == 1)
            {
                GameObject sence = Instantiate(fast_sence, pos, Quaternion.identity) as GameObject;
                sence.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                sence_count++;
            };
            if (random == 2)
            {
                GameObject sence = Instantiate(whitespace, pos, Quaternion.identity) as GameObject;
                sence.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                sence_count++;
            };
            if (random == 3)
            {
                GameObject sence = Instantiate(slide_sence, pos, Quaternion.identity) as GameObject;
                sence.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                sence_count++;
            };
        }
    }


    // Use this for initialization
    void Start()
    {
        Chart_Rigidbody = GetComponent<Rigidbody2D>();
        panel_transform = GameObject.Find("Canvas/Panel_Game").GetComponent<Transform>();
        coin_Voice = GameObject.Find("Canvas/coin_Voice").GetComponent<AudioSource>();
        coin_Text = GameObject.Find("Canvas/coin_Text").GetComponent<Text>();
        Main_Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        image_time= GameObject.Find("Canvas/password_Bg").GetComponent<Image>();
        up = GameObject.Find("Canvas/up").GetComponent<Button>();
        
        right = GameObject.Find("Canvas/password_Bg/right").GetComponent<Button>();
        Text_passward = GameObject.Find("Canvas/password_Bg/InputField/Text").GetComponent<Text>();
        Cht_transform = GetComponent<Transform>();
        sence_count = 2;
        locktime = PlayerPrefs.GetInt("password_time");


    }
    //控制最大速度
    void speedcontrol()
    {
        speedx = Chart_Rigidbody.velocity.x;
        speedy = Chart_Rigidbody.velocity.y;
        //最大到maxspped 最小到-maxspped
        float speed = Mathf.Clamp(speedx, -maxspped, maxspped);
        Chart_Rigidbody.velocity = new Vector2(speed, speedy);
    }
    //時間等待
    IEnumerator maxspeed_Wait()
    {
        yield return new WaitForSeconds(3);
        maxspped = 20f;
    }
    //時間等待 死亡三秒後跳到選單
    IEnumerator time_Wait()
    {
        yield return new WaitForSeconds(3);
        Main_Camera.transform.position = new Vector3(panel_transform.position.x, panel_transform.position.y, -10);        
    }

   
    // Update is called once per frame
    void Update()
    {
        ground = false;
        
        //遊戲開始時間
        time_f = Time.time;
        time_i = Mathf.FloorToInt(time_f);    
        
        //設定密碼 若是還沒輸入過密碼
        if (PlayerPrefs.GetInt("on")==1)
        {
            //遊戲時間超過密碼時間locktime
            if (time_i > locktime)
            {
                PlayerPrefs.SetInt("deleaton", 0);
                is_Activity = false;
                //攝影機移動到 輸入密碼畫面
                Chart_Rigidbody.velocity = new Vector2(0, 0); 
                Main_Camera.transform.position = new Vector3(image_time.transform.position.x, image_time.transform.position.y, -10);
                //按鈕
                if (right)
                {                
                    //輸入正確密碼 
                    if (Text_passward.text == PlayerPrefs.GetString("password"))
                    {
                        //回歸存活狀態 密碼正確
                        PlayerPrefs.SetInt("on", 0);
                        is_Activity = true;
                        PlayerPrefs.SetInt("delaeton", 1);
                    }

                }
            }
        }
        //計分移動
        coin_Text.text = "分數:" + coin_Point+"分";
        Vector2 pos = new Vector2(Cht_transform.position.x+9.4f, 4f);
        coin_Text.transform.position = pos;
        //button移動
        Vector3 pos_Buttonup = new Vector3(Cht_transform.position.x-3f,-1f,0f);
        Vector3 pos_Buttondown = new Vector3(Cht_transform.position.x-3f, -3f,80f);
        up.transform.position =pos_Buttonup ;

        //存活狀態
        if (is_Activity)
        {
            //攝影機追隨腳色
            Vector3 followPos = new Vector3(Cht_transform.position.x + 3.525f, 0, -10);
            Main_Camera.transform.position = followPos;
            //控制速度
            speedcontrol();
            Chart_Rigidbody.AddForce(Vector2.right * addforce);
            //內部測試 按下K刪除資料
            if (Input.GetKey(KeyCode.K))
                PlayerPrefs.DeleteAll();
                

        }
        
           
    }
   
}
