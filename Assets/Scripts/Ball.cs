using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public bool inPlay = false;
    public float launchSpped;
    public Vector3 launchVelocity;

    private Rigidbody rigidbody;
    private AudioSource audioSource;
    private Vector3 ballStartPos;
	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        ballStartPos = transform.position;
        //Launch(launchVelocity);
    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rigidbody.useGravity = true;
        rigidbody.velocity = velocity;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Reset()
    {
        Debug.Log("Reset ball");
        inPlay = false;
        transform.position = ballStartPos;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.useGravity = false;
    }

}
