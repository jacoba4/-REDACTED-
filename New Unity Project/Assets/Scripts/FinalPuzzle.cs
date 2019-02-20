using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzle : MonoBehaviour
{

    public bool moving;
    public int currsymbol;
    int finalcount;
    GameObject[] faces;

    // Start is called before the first frame update
    void Start()
    {
        finalcount = 5;
        moving = false;
        currsymbol = 1;
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
            }
        }
        else
        {
            Reset();
        }
    }

    void Reset()
    {
        currsymbol = 1;
        foreach(GameObject face in faces)
        {
            face.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

}
