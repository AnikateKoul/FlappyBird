using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float gameZone = -14;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        destroyPipe();
    }

    void destroyPipe()
    {
        if (transform.position.x < gameZone)
        {
            Destroy(gameObject);
        }
    }
}
