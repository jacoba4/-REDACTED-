using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackCube : MonoBehaviour
{
    public bool moving;
    float t = 0;
    GameObject[] faces;
    public bool solved;


    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        solved = false;
        faces = GameObject.FindGameObjectsWithTag("Face");
    }

    // Update is called once per frame
    void Update()
    {      
        if(!moving && !solved)
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
        if(!m)
        {
            CheckSol();
        }
    }

    IEnumerator Rotxminus()
    {
        float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated <= 90)
       {
           transform.Rotate(0,Mathf.Lerp(1.75f,0,t),0,Space.World);
           degrees_rotated += Mathf.Lerp(1.75f,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       SetMoving(false);
       CheckSol();
        
    }

    IEnumerator Rotxplus()
    {
        float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated <= 90)
       {
           transform.Rotate(0,-Mathf.Lerp(1.75f,0,t),0,Space.World);
           degrees_rotated += Mathf.Lerp(1.75f,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       SetMoving(false);
       CheckSol();
        
    }

    IEnumerator Rotyminus()
    {
         float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated <= 90)
       {
           transform.Rotate(-Mathf.Lerp(1.75f,0,t),0,0,Space.World);
           degrees_rotated += Mathf.Lerp(1.75f,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       SetMoving(false);
       CheckSol();
        
    }

    IEnumerator Rotyplus()
    {
         float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated <= 90)
       {
           transform.Rotate(Mathf.Lerp(1.75f,0,t),0,0,Space.World);
           degrees_rotated += Mathf.Lerp(1.75f,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       SetMoving(false);
       CheckSol();
        
    }

    void CheckSol()
    {
        bool allpowered = true;
        foreach  (Transform face in transform)
        {
            if(!face.GetComponent<HackFace>().powered)
            {
                allpowered = false;
            }
            foreach (Transform edge in face)
            {
                HackEdge fscript = edge.GetComponent<HackEdge>();
                HackFace fface = fscript.transform.parent.GetComponent<HackFace>();
                HackEdge ofscript = fscript.other.GetComponent<HackEdge>();
                HackFace offace = ofscript.transform.parent.GetComponent<HackFace>();
                if(fscript.mode == HackEdge.Modes.Receive && ofscript.mode == HackEdge.Modes.Give && offace.powered == true && fface.powered == false)
                {
                    fface.powered = true;
                    CheckSol();
                }
            }
        }

        if(allpowered)
        {
            print("Puzzle Solved!");
            solved = true;
        }

    }

    
}
