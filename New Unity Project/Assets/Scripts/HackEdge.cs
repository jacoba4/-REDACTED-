using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackEdge : MonoBehaviour
{
    public enum Modes
    {
        None,
        Give,
        Receive
    };

    public Modes mode;
    public GameObject other;
    // Start is called before the first frame update
    void Start()
    {
        other = null;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter(Collider o)
    {
        if(o.transform.tag == "Edge")
        {
            other = o.gameObject;
        }
    }
}
