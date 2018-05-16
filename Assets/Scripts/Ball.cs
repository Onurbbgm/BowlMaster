using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public bool inPlay = false;
    public float launchSpped;
    public Vector3 launchVelocity;

    private Rigidbody rigidbody;
    private AudioSource audioSource;
	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

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
}
