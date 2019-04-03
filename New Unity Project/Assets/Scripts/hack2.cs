using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hack2 : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Activate()
    {
        cam.enabled = true;
    }
}
