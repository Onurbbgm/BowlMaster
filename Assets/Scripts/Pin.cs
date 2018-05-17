using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 10f;

    private void Awake()
    {
        this.GetComponent<Rigidbody>().solverVelocityIterations = 10;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        print(name + IsStanding());
    }

    public bool IsStanding()
    {
        //print(transform.rotation.eulerAngles);

        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);
        //print(tiltInX +" "+ tiltInZ);

        if(tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        }

        return false;
    }

}
