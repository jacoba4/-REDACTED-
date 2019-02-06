using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFace : MonoBehaviour
{
    public bool moving;
    GameObject[] faces;
    GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        faces = GameObject.FindGameObjectsWithTag("Face");
        cube = GameObject.FindGameObjectWithTag("Cube");
    }

    // Update is called once per frame
    void Update()
    {
              
    }

    void OnMouseDown()
    {
        if(!moving)
        {
            StartCoroutine("Rotxplus");
            SetMoving(true);
        }
    }

    void GetMoving(bool m)
    {
        moving = m;
    }

    void SetMoving(bool m)
    {
        cube.SendMessage("GetMoving", m);
        for(int i = 0; i < faces.Length; i++)
        {
            faces[i].SendMessage("GetMoving",m);
        }
    }

    IEnumerator Rotxplus()
    {
        float t = 0;
        float degrees_rotated = 0;
       while(degrees_rotated <= 90)
       {
           transform.Rotate(0,0,-Mathf.Lerp(2,0,t),Space.World);
           degrees_rotated += Mathf.Lerp(2,0,t);
           t+=.5f*Time.deltaTime;
           yield return null;
       }
       SetMoving(false);
        
    }
}
