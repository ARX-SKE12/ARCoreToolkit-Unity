using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class PlaneTracker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Session.Status == SessionStatus.Tracking)
        {
            
        }
	}
}
