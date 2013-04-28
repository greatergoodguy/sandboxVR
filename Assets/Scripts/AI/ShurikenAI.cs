using UnityEngine;
using System.Collections;

public class ShurikenAI : MonoBehaviour {
	
	private float velocity = 2.0f;
	private Vector3 launchDirection;
	
	void Start () {
		launchDirection = GameObject.Find("OVRPlayerController/ForwardDirection").transform.forward;
		DebugUtils.Assert(launchDirection != null);
		print ("launchDirection: " + launchDirection);
	}
	
	void Update () {
		float angle = 540;		
        transform.RotateAround (transform.localPosition, Vector3.up, angle * Time.deltaTime);
		
		Vector3 movement = launchDirection * Time.deltaTime * velocity;
		transform.Translate(movement, Space.World);
	}
}
