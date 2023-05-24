using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VctorZero : MonoBehaviour
{
    Rigidbody rb;

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit!");
    }*/
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Rigidbodyを停止
            rb.velocity = Vector3.zero;

            Debug.Log("STOP!");
        }
    }
    
}
