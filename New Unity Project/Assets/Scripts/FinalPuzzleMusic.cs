using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleMusic : MonoBehaviour
{
    public bool play;
    public AudioClip[] musicclips;
    public AudioSource source;
    public int numsolved;
    // Start is called before the first frame update
    void Start()
    {
        play = false;
        numsolved = 0;
        source.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(play && !source.isPlaying)
        {
            Music();
        }
    }

    void Music()
    {
        source.clip = musicclips[numsolved];
        source.Play();
    }
}
