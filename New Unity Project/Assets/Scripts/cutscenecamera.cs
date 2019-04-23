using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscenecamera : MonoBehaviour
{
    public float speed;
    bool started;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Camera>().enabled && !started)
        {
            StartCoroutine("move");
            started = true;
        }
    }

    IEnumerator move()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*speed);
        yield return new WaitForSeconds(3f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        yield return null;
    }
}
