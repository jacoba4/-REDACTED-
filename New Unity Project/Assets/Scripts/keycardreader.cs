using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycardreader : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Open()
    {
        GameObject.FindGameObjectWithTag("door1").SendMessage("MoveTheDoor");
    }
}
