using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using OscJack;

public class osc_rectest : MonoBehaviour
{

    public GameObject   one;
    public GameObject   two;
    public GameObject   three;
    public GameObject   fuor;
    public GameObject   five;
    public GameObject   six;


    private OscServer   _server;

    private Vector3     _pos;
    private string      _mess_FL;
    private string      _mess_FR;
    private string      _mess_ML;
    private string      _mess_MR;
    private string      _mess_RL;
    private string      _mess_RR;

    private string      tmp_FL = null;
    private string      tmp_FR = null;
    private string      tmp_ML = null;
    private string      tmp_MR = null;
    private string      tmp_RL = null;
    private string      tmp_RR = null;



    public AudioClip sound1;
    AudioSource audioSource_FL;

    // Use this for initialization
    void Start()
    {

        _server = new OscServer(12000); // Port number

        
        _server.MessageDispatcher.AddCallback(
            "/pos/x",
            (string address, OscDataHandle data) =>
            {
                _pos.x = data.GetElementAsFloat(0);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/pos/y",
            (string address, OscDataHandle data) =>
            {
                _pos.y = data.GetElementAsFloat(0);
            }
        );
        _server.MessageDispatcher.AddCallback(
            "/pos/z",
            (string address, OscDataHandle data) =>
            {
                _pos.z = data.GetElementAsFloat(0);
            }
        );

        
        _server.MessageDispatcher.AddCallback(
            "/mess_FL",
            (string address, OscDataHandle data) =>
            {
                _mess_FL = data.GetElementAsString(0);
            }
        );

        _server.MessageDispatcher.AddCallback(
            "/mess_FR",
            (string address, OscDataHandle data) =>
            {
                _mess_FR = data.GetElementAsString(0);
            }
        );

        _server.MessageDispatcher.AddCallback(
            "/mess_ML",
            (string address, OscDataHandle data) =>
            {
                _mess_ML = data.GetElementAsString(0);
            }
        );

        _server.MessageDispatcher.AddCallback(
            "/mess_MR",
            (string address, OscDataHandle data) =>
            {
                _mess_MR = data.GetElementAsString(0);
            }
        );

        _server.MessageDispatcher.AddCallback(
            "/mess_RL",
            (string address, OscDataHandle data) =>
            {
                _mess_RL = data.GetElementAsString(0);
            }
        );

        _server.MessageDispatcher.AddCallback(
            "/mess_RR",
            (string address, OscDataHandle data) =>
            {
                _mess_RR = data.GetElementAsString(0);
            }
        );


        //Componentを取得
        //audioSource_FL = GetComponent<AudioSource>();
        audioSource_FL = GameObject.Find("s_cube_FL").GetComponent<AudioSource>();

    }

    private void OnDestroy()
    {
        _server.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        //_light.color = _color;
        //_light.transform.eulerAngles = _rot;
        //one.transform.localPosition = _pos;

        //messTestで更新された時のみconsoleに出力
        if(_mess_FL != tmp_FL)
        {
            Debug.Log(_mess_FL);
            if(_mess_FL == "On")
            {
                //audioSource_FL.PlayOneShot(sound1);
                audioSource_FL.PlayOneShot(sound1);

            }
        }
        tmp_FL = _mess_FL;
        /*
        if (_mess_FR != tmp_FR)
        {
            Debug.Log(_mess_FR);
            if (_mess_FR == "On")
            {
                audioSource.PlayOneShot(sound1);
            }
        }
        tmp_FR = _mess_FR;

        if (_mess_ML != tmp_ML)
        {
            Debug.Log(_mess_ML);
            if (_mess_ML == "On")
            {
                audioSource.PlayOneShot(sound1);
            }
        }
        tmp_ML = _mess_ML;

        if (_mess_FL != tmp_FL)
        {
            Debug.Log(_mess_FL);
            if (_mess_FL == "On")
            {
                audioSource.PlayOneShot(sound1);
            }
        }
        tmp_MR = _mess_MR;

        if (_mess_RL != tmp_RL)
        {
            Debug.Log(_mess_RL);
            if (_mess_RL == "On")
            {
                audioSource.PlayOneShot(sound1);
            }
        }
        tmp_RL = _mess_RL;

        if (_mess_RR != tmp_RR)
        {
            Debug.Log(_mess_RR);
            if (_mess_RR == "On")
            {
                audioSource.PlayOneShot(sound1);
            }
        }
        tmp_RR = _mess_RR;

        //Debug.Log(_mess);*/
    }
}
