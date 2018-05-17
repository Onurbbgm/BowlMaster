﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanging().ToString();
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

}