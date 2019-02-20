using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleFace : MonoBehaviour
{
    public int order;
    public GameObject puzzle;
    FinalPuzzle script;
    // Start is called before the first frame update
    void Start()
    {
        puzzle = GameObject.FindGameObjectWithTag("FinalPuzzle");
        script = puzzle.GetComponent<FinalPuzzle>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        script.SendMessage("Check",order);
       
    }
}
