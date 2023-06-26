using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeRenderScript : MonoBehaviour
{
    public GameObject gameobject;
    public float renderTime = 2;
    public float offsetRange = 10;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        createPipe();   
    }

    // Update is called once per frame
    void Update()
    {
        renderPipe();
    }

    void renderPipe()
    {
        if(timer < renderTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            createPipe();
        }
    }

    void createPipe()
    {
        float minHeight = transform.position.y - offsetRange;
        float maxHeight = transform.position.y + offsetRange;
        Instantiate(gameobject, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
    }

}
