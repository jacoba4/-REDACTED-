using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeCode : MonoBehaviour
{
    string code;
    int curr;

    public CanvasControl currCanvas;
    // Start is called before the first frame update
    void Start()
    {
        code = "3846";
        curr = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pressed(int num)
    {
        if(num == code[curr])
        {
            Debug.Log("num input");
            curr++;
        }
        else
        {
        
        }

        if(curr == 4)
        {
            currCanvas.SendMessage("NumPadOff");
            Solved();
        }
    }

    void Reset()
    {
        curr = 0;
        //Reset safe ui if need be?
    }

    void Solved()
    {
        GetComponent<Safe>().SendMessage("Open");
        //Also set safe ui to close
    }

    
}
