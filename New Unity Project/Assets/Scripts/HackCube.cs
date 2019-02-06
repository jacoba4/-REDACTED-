using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackCube : MonoBehaviour
{
    float ymove;
    float xmove;
    public float rotspeed;
    public Vector3 point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotspeed);
        //float yrot = Input.GetAxis("Mouse Y") * rotspeed * Time.deltaTime;
        //float xrot = -Input.GetAxis("Mouse X") * rotspeed * Time.deltaTime;
        //Quaternion rotation = Quaternion.Euler(yrot,xrot,0);
        //transform.rotation = rotation;

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * Time.deltaTime*rotspeed, Space.World);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime*rotspeed, Space.World);
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-Vector3.left * Time.deltaTime*rotspeed, Space.World);
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left * Time.deltaTime*rotspeed, Space.World);
        }
       
    }
}
