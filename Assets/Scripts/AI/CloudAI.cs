using UnityEngine;
using System.Collections;

public class CloudAI : MonoBehaviour {
	public RotationDirection rotationDirection = RotationDirection.None;
	
	private float RADIANS_TO_DEGREES_FACTOR = 57.2957795f;
	
	public float metersPerSecond = 1;
	
	private float RADIUS;
	private Vector3 CENTER_POINT;
	
	void Start () {
		CENTER_POINT = Vector3.zero;
		CENTER_POINT.y = transform.position.y;
		RADIUS = Vector3.Distance(transform.position, CENTER_POINT);	
	}
	
	// Update is called once per frame
	void Update () {
		float radians = Mathf.Atan( metersPerSecond / RADIUS);
		float degrees = 0;
		
		switch(rotationDirection){
		case RotationDirection.None:
			degrees = 0;
			break;
		case RotationDirection.Clockwise:
			degrees = radians * RADIANS_TO_DEGREES_FACTOR;
			break;
		case RotationDirection.CounterClockwise:
			degrees = radians * RADIANS_TO_DEGREES_FACTOR * -1;
			break;
		default:
			DebugUtils.Assert(false);
			break;
		}
		
        // Spin the object around the world origin at X degrees/second. X = degrees.
        transform.RotateAround (CENTER_POINT, Vector3.up, degrees * Time.deltaTime);
 
	}
}
