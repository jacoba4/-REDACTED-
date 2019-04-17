using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    int currentdigit;
    // Start is called before the first frame update
    void Start()
    {
        currentdigit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Open()
    {
        MeshCollider[] mc = GetComponentsInChildren<MeshCollider>();
        foreach (MeshCollider m in mc)
        {
            m.enabled = false;
        }
        GetComponent<Animator>().SetTrigger("Open");
    }
}
