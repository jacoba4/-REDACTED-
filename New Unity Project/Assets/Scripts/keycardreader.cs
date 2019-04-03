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
        door.transform.localPosition = new Vector3(-173.4f,0f,0f);
    }
}
