using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finaldoorright : MonoBehaviour
{
    private Vector3 shift;
    private Vector3 start;
    float i;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.localPosition;
        shift = new Vector3(10.66f,0f,0f);
        i = 0;
        speed = .05f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Solved()
    {
        //transform.localPosition = new Vector3(160f,0f,0f);
        StartCoroutine("doormove");
    }
    
    IEnumerator doormove()
    {
        while(transform.localPosition != shift)
        {
            transform.localPosition = Vector3.Lerp(start,shift,i);
            i+=speed;
            yield return null;
        }

        transform.localPosition = new Vector3(12f,0f,-6f);
        
    }
}
