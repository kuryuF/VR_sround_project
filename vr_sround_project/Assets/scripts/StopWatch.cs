using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StopWatch : MonoBehaviour
{
    private Rigidbody rb;

    public float time;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI TimeTextMeshPro;
    public bool ClockActivated = false;

    public float Warning;　//タイマーが黄色になるしきい値
    public float Dangerous; //タイマーが赤色になるしきい値

    //public OVRInput input;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 0.0f;
        ClockActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        //if (Input.GetKey(KeyCode.S))
        {
            ResetClock();
        }

        else if (ClockActivated == true)
        {
            CountingDown();
        }
        else if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        //else if (Input.GetKey(KeyCode.A))
        {
            CountingDown();
        }

        //　現在時刻を取得するスクリプト
        string clock = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm:ss");
        TimeText.text = clock;


    }


    //タイマー進行スクリプト
    void CountingDown()
    {
        time += Time.deltaTime;
        TimeTextMeshPro.text = time.ToString("F2");


        //　以下経過時間に合わせてテキスト色を変更するスクリプト
        if (time < Warning)
        {
            TimeText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); //タイマー白色設定
            TimeTextMeshPro.color = new Color(1, 1, 1, 1);
        }
        else if (time > Dangerous)
        {
            //TimeText.color = new Color(1.0f, 0, 0, 1.0f);
            TimeTextMeshPro.color = new Color(1, 0, 0, 1); //タイマー危険　赤
        }
        else
        {
            //TimeText.color = new Color(1.0f, 0.92f, 0.016f, 1.0f);
            TimeTextMeshPro.color = new Color(1.0f, 0.92f, 0.016f, 1.0f); //タイマーワーニング　黄色
        }

        ClockActivated = true;
    }

    //時計を止めてリセットするスクリプト
    void ResetClock()
    {
        time = 0.0f;
        //TimeText.text = DateTime.Now.ToLongTimeString();
        TimeTextMeshPro.text = time.ToString("F2");
        //TimeText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        TimeTextMeshPro.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        ClockActivated = false;

    }

    //タグ Respawnに設定されている他のオブジェクトに触れると発動するスクリプト
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            CountingDown();
            /*
            time += Time.deltaTime;
            //TimeText.text = DateTime.Now.ToLongTimeString();
            TimeTextMeshPro.text = time.ToString("F2");
            ClockActivated = true;
            */
        }

    }


    //上記タグ Respawnに設定されている他のオブジェクトから離れると発動するスクリプト
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            ResetClock();
            /*
            time = 0.0f;
            //TimeText.text = DateTime.Now.ToLongTimeString();
            TimeTextMeshPro.text = time.ToString("F2");
            ClockActivated = false;
            */
        }
    }
}
