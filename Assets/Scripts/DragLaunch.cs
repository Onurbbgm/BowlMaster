using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
    public void MoveStart(float amount)
    {
        //Debug.Log("Ball moved " + amount);
        if (!ball.inPlay)
        {
            ball.transform.Translate(new Vector3(amount, 0, 0));
        }

    }

    public void DragStart()
    {
        //Capture time & position of drag start
        dragStart = Input.mousePosition;
        startTime = Time.time;

    }

    public void DragEnd()
    {
        // Launch the ball
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float duration = endTime - startTime;

        float launchSpeedX = (dragEnd.x - dragStart.x) / duration;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / duration;
        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        ball.Launch(launchVelocity);
    }
	
}
