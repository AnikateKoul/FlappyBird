using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeRenderScript : MonoBehaviour
{
    public GameObject normalPipe;
    public GameObject specialPipe;
    public float renderTime = 2;
    public float offsetRange = 10;
    private float timer = 0;
    private int pipeCount = 0;
    public int desiredCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        createNormalPipe();   
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
            if(pipeCount == desiredCount)
            {
                createSpecialPipe();
            }
            else
            {
                createNormalPipe();

            }
        }
    }

    void createNormalPipe()
    {
        float minHeight = transform.position.y - offsetRange;
        float maxHeight = transform.position.y + offsetRange;
        Instantiate(normalPipe, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
        pipeCount++;
    }

    void createSpecialPipe()
    {
        float minHeight = transform.position.y - offsetRange;
        float maxHeight = transform.position.y + offsetRange;
        Instantiate(specialPipe, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
        pipeCount = 0;
    }

}
