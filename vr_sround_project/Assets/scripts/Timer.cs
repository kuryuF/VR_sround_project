using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float countTime = 0;

    public bool isTimeUp;
    public bool button;

  
    public OVRInput.Controller m_controller;



    void Start()
    {
        isTimeUp = false;
        button = false;
    }



    // Update is called once per frame
    void Update()
    {
        button = true;

        if( button == true)
        {
            Countingdown();
        }

        /*if(Input.GetKeyDown(KeyCode.A))
        {
            button = true;

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            button = false;
            countTime = 0;

        }*/
    }

    void Countingdown()
    {
        //if (Input.GetKey(KeyCode.A))

        // countTimeに、ゲームが開始してからの秒数を格納
        countTime += Time.deltaTime;

        // 小数2桁にして表示
        GetComponent<Text>().text = countTime.ToString("F2");

    }
}