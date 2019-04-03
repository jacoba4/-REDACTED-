using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackCube : MonoBehaviour
{
    public bool moving;
    float t = 0;
    GameObject[] faces;
    public bool solved;
    public PlayerCam player;
    public GameObject link;
    public Camera disable;
    public HackFace begin;
    public HackFace end;


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

    IEnumerator Rot(Vector3 byAngles,float intime)
    {
        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for(float i = 0f; i <= 1; i+= Time.deltaTime/intime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle,toAngle,i);
            yield return null;
        }
        transform.rotation = toAngle;
        SetMoving(false);
    }

    
    IEnumerator Rotxminus()
    {
        float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated < 90)
       {
           transform.Rotate(0,Mathf.Lerp(1.75f,0,t),0,Space.World);
           degrees_rotated += Mathf.Lerp(1.75f,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       Normalize();
       SetMoving(false);
       CheckSol();
        
    }

    IEnumerator Rotxplus()
    {
        float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated < 90)
       {
           transform.Rotate(0,-Mathf.Lerp(1.75f,0,t),0,Space.World);
           degrees_rotated += Mathf.Lerp(1.75f,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       Normalize();
       SetMoving(false);
       CheckSol();
        
    }

    IEnumerator Rotyminus()
    {
         float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated < 90)
       {
           transform.Rotate(-Mathf.Lerp(1.75f,0,t),0,0,Space.World);
           degrees_rotated += Mathf.Lerp(1.75f,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       Normalize();
       SetMoving(false);
       CheckSol();
        
    }

    IEnumerator Rotyplus()
    {
         float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated < 90)
       {
           transform.Rotate(Mathf.Lerp(1.75f,0,t),0,0,Space.World);
           degrees_rotated += Mathf.Lerp(1.75f,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       Normalize();
       SetMoving(false);
       CheckSol();
        
    }

    void Normalize()
    {
        transform.eulerAngles = new Vector3(Mathf.Round(transform.eulerAngles.x),Mathf.Round(transform.eulerAngles.y),Mathf.Round(transform.eulerAngles.z));
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
            Solved();
        }

    }


    /* WIP: ALMOST DONE
    void CheckSol(HackFace x)
    {
        if(x == end)
        {
            Solved();
            return;
        }
        
        HackFace current = x;
        bool visited = false;

        for(int i = 0; i < 10; i++)
        {
            if(current == end)
            {
                Solved();
                break;
            }

            List<HackFace> previous = new List<HackFace>();
            previous.Add(begin);

            foreach(Transform edge in current.transform)
            {
                HackEdge cedge = edge.GetComponent<HackEdge>();
                HackEdge oedge = cedge.other.GetComponent<HackEdge>();
                if(cedge.mode == HackEdge.Modes.Give && oedge.mode == HackEdge.Modes.Give)
                {
                    for(int j = 0; j < previous.Count; j++)
                    {
                        if(oedge.transform.parent.GetComponent<HackFace>() == previous[j])
                        {
                            visited = true;
                            break;
                        }
                    }

                    if(visited)
                    {
                        continue;
                    }

                    previous.Add(oedge.transform.parent.GetComponent<HackFace>());
                    visited = false;
                    current = oedge.transform.parent.GetComponent<HackFace>();
                }
            }
        }
    }*/

    void Solved()
    {
        print("YOSH!");
        disable.enabled = false;
        player.SendMessage("Solved");
        //link.SendMessage("Solved");
    }

    
}
