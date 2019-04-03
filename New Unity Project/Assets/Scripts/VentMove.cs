using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentMove : MonoBehaviour
{
    private Vector3 shift;
    private Vector3 rot;
    private bool shifted;

    // Start is called before the first frame update
    void Start()
    {
        shifted = false;
        shift = new Vector3(-96.5f, 753.7f, 883);
    }

    // Update is called once per frame
    void Update()
    {
         if (shifted == true)
        {
            //transform.position = shift;
        }
    }
    void MoveTheVent()
    {
        
        //rot.Set(90, 0, 0);
        transform.Rotate(90, 0, 0);
        shifted = true;
        transform.localPosition = new Vector3(-96.5f, 753.5f, 883f);
        //transform.position = shift;
        
    }
}
