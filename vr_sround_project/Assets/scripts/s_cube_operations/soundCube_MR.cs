using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using OscJack;


public class soundCube_MR : MonoBehaviour
{

    public GameObject target;

    private OscServer _server;
    private Vector3 _pos;
    private string _triger;
    private string tmp;

    public AudioClip sound1;
    AudioSource audioSource;


    void Start()
    {

        _server = new OscServer(9004); // Port number

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
            "/mess",
            (string address, OscDataHandle data) =>
            {
                _triger = data.GetElementAsString(0);
            }
        );

        audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        _server.Dispose();
    }

    void Update()
    {
        target.transform.localPosition = _pos;
        //Debug.Log(_pos);

        if (_triger != tmp)
        {
            Debug.Log(_triger);
            if (_triger == "On")
            {
                audioSource.PlayOneShot(sound1);
            }
        }
        tmp = _triger;
    }
}