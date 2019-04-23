using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPuzzle : MonoBehaviour
{

    public bool moving;
    public int currsymbol;
    int finalcount;
    GameObject[] faces;
    public Camera playercam;
    public GameObject pod;
    public GameObject alien;
    FinalPuzzleMusic fpm;
    public GameObject light1;
    public GameObject light2;

    // Start is called before the first frame update
    void Start()
    {
        finalcount = 6;
        moving = false;
        currsymbol = 0;
        faces = GameObject.FindGameObjectsWithTag("FinalPuzzleFace");
        fpm = gameObject.GetComponent<FinalPuzzleMusic>();
    }

    // Update is called once per frame
    void Update()
    {
        fpm.numsolved = currsymbol;
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
                playercam.SendMessage("Solved");
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
        GameObject.FindGameObjectWithTag("crosshair").SetActive(false);
        light1.GetComponent<Light>().color = Color.red;
        light2.GetComponent<Light>().color = Color.red;
        StartCoroutine("Flicker");
        yield return new WaitForSeconds(4f);
        alien.GetComponent<Animator>().SetTrigger("Eyes");
        //GameObject.FindGameObjectWithTag("Cutscene Camera").GetComponent<Camera>().enabled = false;
        //GameObject.FindGameObjectWithTag("Cutscene Camera 2").GetComponent<Camera>().enabled = true;
        
        
        //play sound
        alien.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(.25f);
        alien.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*-435);
        
        yield return new WaitForSeconds(.4f);
        Camera cscam = GameObject.FindGameObjectWithTag("Cutscene Camera").GetComponent<Camera>();
        cscam.enabled = false;
        GameObject.FindGameObjectWithTag("Black Camera").GetComponent<Camera>().enabled = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("EndScreen");

    }

    IEnumerator Flicker()
    {
        while(true)
        {
            light1.GetComponent<Light>().enabled = false;
            light2.GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(.1f);
            light1.GetComponent<Light>().enabled = true;
            light2.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(.1f);
        }

    }

    void Reset()
    {
        currsymbol = 0;
        foreach(GameObject face in faces)
        {
            SpriteRenderer s = face.GetComponent<SpriteRenderer>();
            s.sprite = face.GetComponent<FinalPuzzleFace>().unpowered;
        }
    }

}
