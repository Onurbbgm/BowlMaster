using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 10f;
    public float distanceToRaise = 40f;

    private Rigidbody rigidbody;

    private void Awake()
    {
        this.GetComponent<Rigidbody>().solverVelocityIterations = 10;
    }

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
      //print(name + IsStanding());
    }

    public bool IsStanding()
    {
        //print(transform.rotation.eulerAngles);

        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);
        //print(tiltInX +" "+ tiltInZ);

        if(tiltInX < standingThreshold || tiltInZ < standingThreshold)
        {
            return true;
        }

        return false;
    }

    public void Raise()
    {
        //raise standing pins only by the distanceToRaise
        if (IsStanding())
        {
            rigidbody.useGravity = false;
            transform.Translate(new Vector3(0f, distanceToRaise, 0f), Space.World);
        }
        
        Debug.Log("Raising pins");
    }

    public void Lower()
    {
        if (IsStanding())
        {
            transform.Translate(new Vector3(0f, -distanceToRaise, 0f), Space.World);
            rigidbody.useGravity = true;
            rigidbody.freezeRotation = true;
        }
        Debug.Log("Lower pins");
    }

    public void ResetPin()
    {
        if (gameObject)
        {
            rigidbody.freezeRotation = false;
            rigidbody.useGravity = true;
        }
    }

    //One solution to remove the pins when they leave play area
    //private void OnTriggerExit(Collider collider)
    //{
    //    if (collider.gameObject.GetComponent<PinSetter>())
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
