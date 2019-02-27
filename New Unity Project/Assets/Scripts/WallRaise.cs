using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRaise : MonoBehaviour
{
    Vector3 endPoint;
    Vector3 startPoint;

    private float currentTime;
    public float speed = .2f;
    private float startTime;

    public bool move;

    private float journey;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        endPoint = new Vector3(0, .688f, 0);

        //startTime = Time.time;
        move = false;

        // Calculate the journey length.
        journey = Vector3.Distance(startPoint, endPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (move == false)
        {
            startTime = Time.time;
        }
        if (move == true)
        {
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journey;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startPoint, endPoint, fracJourney);
            /*if (transform.position != endPoint)
            {
                transform.position += new Vector3(0, speed, 0);
            }*/
                

        }
    }
}
