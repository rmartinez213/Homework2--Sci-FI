using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform movingPlatform;
    public Transform position1;
    public Transform position2;
    public Vector3 newPosition;
    public int currentState = 0; //0 == inital, 1 == pos1, 2==pos2
    public float moveDuration;
    public float resetTime;



    // Use this for initialization
    void Start()
    {
        ChangeTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, moveDuration * Time.deltaTime);
    }

    void ChangeTarget()
    {
        if (currentState == 0)
        { // go to pos 2, then set curr state to 1
            currentState = 2;
            newPosition = position2.position;
        }

        else if (currentState == 2)
        { // go to pos 2, then set curr state to 1
            currentState = 1;
            newPosition = position1.position;
        }

        else if (currentState == 1)
        {
            currentState = 2;
            newPosition = position2.position;
        }

        Invoke("ChangeTarget", resetTime);

    }

}