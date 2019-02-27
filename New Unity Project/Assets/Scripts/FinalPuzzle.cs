using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzle : MonoBehaviour
{

    public bool moving;
    public int currsymbol;
    int finalcount;
    GameObject[] faces;
    public Camera playercam;
    public GameObject pod;
    public GameObject alien;
    public GameObject alienparent;

    // Start is called before the first frame update
    void Start()
    {
        finalcount = 6;
        moving = false;
        currsymbol = 0;
        faces = GameObject.FindGameObjectsWithTag("FinalPuzzleFace");
    }

    // Update is called once per frame
    void Update()
    {
        if(!moving)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine("Rot",60f);
                SetMoving(true);
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine("Rot",-60f);
                SetMoving(true);
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                GameObject.FindGameObjectWithTag("FinalPuzzleCam").SendMessage("SwitchOff");
                playercam.enabled = true;
                Cursor.visible = false;
                playercam.transform.GetComponent<PlayerCam>().SendMessage("LockCursor");
            }
        }
    }


    void SetMoving(bool x)
    {
        moving = x;
    }

    IEnumerator Rot(float degrees)
    {
        float t = 0;
        float degrees_rotated = 0;
        float target = transform.eulerAngles.y + degrees;
       while(Mathf.Abs(degrees_rotated) <= 60)
       {
           float lerp = 0;
           if(degrees > 0)
           {
                lerp = Mathf.Lerp(2,0,t);
           }

           else if(degrees < 0)
           {
               lerp = -Mathf.Lerp(2,0,t);
           }
           transform.Rotate(0,lerp,0,Space.World);
           degrees_rotated += lerp;
           t+=.1f*Time.deltaTime;
           yield return null;
       }
       transform.eulerAngles = new Vector3(transform.eulerAngles.x,target,transform.eulerAngles.z);
       SetMoving(false);
        
    }

    void Check(int x)
    {
        if(x == currsymbol)
        {
            currsymbol++;
            if(currsymbol == finalcount)
            {
                print("SOLVED :D");
                GameObject.FindGameObjectWithTag("FinalPuzzleCam").SendMessage("SwitchOff");
                GameObject.FindGameObjectWithTag("Cutscene Camera").GetComponent<Camera>().enabled = true;
                pod.GetComponent<Animator>().SetTrigger("Open");
                GameObject[] particles = GameObject.FindGameObjectsWithTag("particle");
                foreach(GameObject particle in particles)
                {
                    particle.GetComponent<ParticleSystem>().Play();
                }
                pod.GetComponent<AudioSource>().Play();
                /*                alienparent.transform.localScale = new Vector3(24,24,24);
                alienparent.transform.position = new Vector3(-6.933f,28.699f,95.27f);*/
                StartCoroutine("AnimWait");
            }
        }
        else
        {
            Reset();
        }
    }

    IEnumerator AnimWait()
    {
        yield return new WaitForSeconds(4f);
        alien.GetComponent<Animator>().SetTrigger("Eyes");
        GameObject.FindGameObjectWithTag("Cutscene Camera").GetComponent<Camera>().enabled = false;
        GameObject.FindGameObjectWithTag("Cutscene Camera 2").GetComponent<Camera>().enabled = true;
        
    }

    void Reset()
    {
        print("Resetting");
        currsymbol = 0;
        foreach(GameObject face in faces)
        {
            SpriteRenderer s = face.GetComponent<SpriteRenderer>();
            s.sprite = face.GetComponent<FinalPuzzleFace>().unpowered;
        }
    }

}
