using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentMove : MonoBehaviour
{
    private Vector3 shift;
    private Vector3 rot;
    private Vector3 start;
    private bool shifted;
    float i;

    // Start is called before the first frame update
    void Start()
    {
        shifted = false;
        start = transform.localPosition;
        shift = new Vector3(-96.5f, 753.7f, 883f);
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
         if (shifted == true)
        {
            transform.localPosition = Vector3.Lerp(start, shift, i);
            i+= .05f;
        }
    }
    void MoveTheVent()
    {
        /* */
        //rot.Set(90, 0, 0);
        //transform.Rotate(90, 0, 0);
        shifted = true;
        //transform.localPosition = new Vector3(-96.5f, 753.5f, 883f);
        //transform.position = shift;
        
    }
}
