using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public Transform other;

    public float dist;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Update()
    {

        Kyori();

    }

    public void Kyori()
    {
        float dist = Vector3.Distance(other.position, transform.position);

        Debug.Log(dist);
    }
}
