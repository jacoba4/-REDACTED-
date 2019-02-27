using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleCam : MonoBehaviour
{
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchHere()
    {
        transform.GetComponent<Camera>().enabled = true;
        crosshair = GameObject.FindGameObjectWithTag("crosshair");
        crosshair.SetActive(false);

    }

    void SwitchOff()
    {
        transform.GetComponent<Camera>().enabled = false;
        crosshair.SetActive(true);
    }
}
