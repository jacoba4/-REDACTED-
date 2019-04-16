using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleCam : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject finalpuzzle;
    
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        finalpuzzle.GetComponent<FinalPuzzleMusic>().play = true;
    }

    void SwitchOff()
    {
        transform.GetComponent<Camera>().enabled = false;
        crosshair.SetActive(true);
        //Turning this off for dramatic effect
        //finalpuzzle.GetComponent<FinalPuzzleMusic>().play = false;
    }


    
}
