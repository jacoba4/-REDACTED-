using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleCam : MonoBehaviour
{
    public GameObject crosshair;
    bool play;
    public AudioClip[] musicclips;
    float timeelapsed;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Camera>().enabled = false;
        play = false;
        timeelapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeelapsed += Time.deltaTime;
        if(play)
        {
            Music();
        }
    }

    void SwitchHere()
    {
        transform.GetComponent<Camera>().enabled = true;
        crosshair = GameObject.FindGameObjectWithTag("crosshair");
        crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        play = true;
    }

    void SwitchOff()
    {
        transform.GetComponent<Camera>().enabled = false;
        crosshair.SetActive(true);
        play = false;
    }


    void Music()
    {
        
    }
}
