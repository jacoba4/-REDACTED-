using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finaldoorcontroller : MonoBehaviour
{
    public GameObject leftdoor;
    public GameObject rightdoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Solved()
    {
        leftdoor.SendMessage("Solved");
        rightdoor.SendMessage("Solved");
    }
}
