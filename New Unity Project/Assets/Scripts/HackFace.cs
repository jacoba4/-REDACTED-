using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFace : MonoBehaviour
{
    public bool moving;
    public bool powered;
    GameObject[] faces;
    GameObject cube;
    public Material powered_mat;
    public Material unpowered_mat;
    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        faces = GameObject.FindGameObjectsWithTag("Face");
        cube = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(powered)
        {
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            if(mesh.material != powered_mat)
            {
                //mesh.material = powered_mat;
            }  
        }
        else
        {
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            if(mesh.material != unpowered_mat)
            {
                //mesh.material = unpowered_mat;
            } 
        }
    }

    void OnMouseDown()
    {
        print("meme2s");
        if(!moving && !cube.GetComponent<HackCube>().solved)
        {
            print("memes");
            StartCoroutine(Rot(Vector3.forward * 90, 0.5f));
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

    /*
    Nah miss, that ain't me no more
    IEnumerator Rotxplus()
    {
        float t = 0;
        float degrees_rotated = 0;
        float target = 0f;
         
        if(transform.eulerAngles.z == 0f)
        {
            target = 90f;
        }
        if(transform.eulerAngles.z == 90f)
        {
            target = 180f;
        }
        if(transform.eulerAngles.z == 180f)
        {
            target = 270f;
        }
        if(transform.eulerAngles.z == 270f)
        {
            target = 0f;
        }
        print("target: " + target);
       print("Current: " + transform.eulerAngles.z);
       while(degrees_rotated < 90)
       {
           transform.Rotate(0,0,Mathf.Lerp(1.75f,0,t),Space.World);
           degrees_rotated += Mathf.Lerp(1.75f,0,t);
           t+=.5f*Time.deltaTime;
           
           yield return null;
       }
       transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,target);
       SetMoving(false);
        
    }*/
}
