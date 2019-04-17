using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : MonoBehaviour
{
    public Light l1;
    public Light l2;
    bool on;
    // Start is called before the first frame update
    void Start()
    {
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Toggle()
    {
        if(on)
        {
            l1.enabled = false;
            l2.enabled = false;
            on = false;
        }
        else if (!on)
        {
            l1.enabled = true;
            l2.enabled = true;
            on = true;
        }

        
    }
}
