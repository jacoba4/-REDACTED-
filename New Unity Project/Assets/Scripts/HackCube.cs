using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackCube : MonoBehaviour
{
    public bool moving;
    float t = 0;
    GameObject[] faces;



    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        faces = GameObject.FindGameObjectsWithTag("Face");
    }

    // Update is called once per frame
    void Update()
    {      
        if(!moving)
        {  
            if(Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine("Rotxminus");
                SetMoving(true);
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine("Rotxplus");
                SetMoving(true);
            }
            else if(Input.GetKeyDown(KeyCode.W))
            {
                StartCoroutine("Rotyplus");
                SetMoving(true);
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine("Rotyminus");
                SetMoving(true);
            } 
        }    
    }

    void SetMoving(bool m)
    {
        moving = m;
        for(int i = 0; i < faces.Length; i++)
        {
            faces[i].SendMessage("GetMoving",m);
        }
    }

    void GetMoving(bool m)
    {
        moving = m;
    }

    IEnumerator Rotxminus()
    {
        float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated <= 90)
       {
           transform.Rotate(0,Mathf.Lerp(2,0,t),0,Space.World);
           degrees_rotated += Mathf.Lerp(2,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       SetMoving(false);
        
    }

    IEnumerator Rotxplus()
    {
        float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated <= 90)
       {
           transform.Rotate(0,-Mathf.Lerp(2,0,t),0,Space.World);
           degrees_rotated += Mathf.Lerp(2,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       SetMoving(false);
        
    }

    IEnumerator Rotyminus()
    {
         float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated <= 90)
       {
           transform.Rotate(-Mathf.Lerp(2,0,t),0,0,Space.World);
           degrees_rotated += Mathf.Lerp(2,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       SetMoving(false);
        
    }

    IEnumerator Rotyplus()
    {
         float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated <= 90)
       {
           transform.Rotate(Mathf.Lerp(2,0,t),0,0,Space.World);
           degrees_rotated += Mathf.Lerp(2,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       SetMoving(false);
        
    }

    
}
