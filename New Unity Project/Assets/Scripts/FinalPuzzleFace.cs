using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleFace : MonoBehaviour
{
    public int order;
    public GameObject puzzle;
    FinalPuzzle script;
    public Sprite unpowered;
    public Sprite powered;
    // Start is called before the first frame update
    void Start()
    {
        puzzle = GameObject.FindGameObjectWithTag("FinalPuzzle");
        script = puzzle.GetComponent<FinalPuzzle>();
        GetComponent<SpriteRenderer>().sprite = unpowered;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = powered;
        script.SendMessage("Check",order);
       
    }
}
