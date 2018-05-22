using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;
    public int lastStandingCount = -1;
    public float distanceToRaise = 40f;
    public GameObject pinSet;

    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanging().ToString();

        if (ballEnteredBox)
        {
            CheckStanding();
        }
	}

    int CountStanging()
    {
        int standingCount = 0;
        //Pin[] pins = GameObject.FindObjectsOfType<Pin>();
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standingCount++;
            }
        }
        return standingCount;
    }

    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.Raise();
            }
        }
    }

    public void PinsIdleState()
    {
        Pin[] pins = GameObject.FindObjectsOfType<Pin>();
        foreach(var pin in pins)
        {
            pin.ResetPin();
        }
        Debug.Log("Pins reseted");
    }

    public void LowerPins()
    {
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.Lower();             
            }
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renew Pins");
        GameObject pins = Instantiate(pinSet, new Vector3(0, distanceToRaise, 1829), Quaternion.identity) as GameObject;
        foreach(Rigidbody rib in pins.GetComponentsInChildren<Rigidbody>())
        {
            rib.freezeRotation = true;
        }
    }

    void CheckStanding()
    {
        //Update the lastStandingCount
        //Call PinsHaveSettled() when they have
        int currentStanding = CountStanging();
        if(currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; //How long to consider pins settled
        if ((Time.time - lastChangeTime)>settleTime) //If last change > 3s ago
        {
            PinsHaveSettled();
        }

    }

    void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1;//Indicates pins have settled, and ball not back in box
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }

    //Another solution to remove the pins when they leave play area
    private void OnTriggerExit(Collider collider)
    {
        Pin pin = collider.gameObject.GetComponentInParent<Pin>();
        //print("somethingLeft");
        if (pin)
        {
            Destroy(pin.gameObject);
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject thingHit = collider.gameObject;
        //Ball enters 
        if (thingHit.GetComponent<Ball>())
        {
            //print("ball entered box");
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }

}
