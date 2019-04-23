using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeCode : MonoBehaviour
{
    int[] code;
    public int curr;

    public CanvasControl currCanvas;
    // Start is called before the first frame update
    void Start()
    {
        code = new int[4];
        code[0] = 3;
        code[1] = 8;
        code[2] = 4;
        code[3] = 6;
        curr = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pressed(int num)
    {
        //Debug.Log(num);
        if(num == code[curr])
        {
            //Debug.Log("num input");
            curr++;
        }
        else
        {
            Reset();
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
        currCanvas.SendMessage("NumPadOff");
    }

    
}
