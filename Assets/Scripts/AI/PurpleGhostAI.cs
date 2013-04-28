using UnityEngine;
using System.Collections;

public class PurpleGhostAI : MonoBehaviour {
	
	
	public float metersPerSecond = 1;
	// This controls how fast the graphics of the character "turns around"
	public float rotationSmoothing = 5.0f;
	
	private float travelDistance = 7;
	
	private float startX;
	private float endX;
	
	private Vector3 leftDirection = new Vector3(0, 0, -1);
	private Vector3 rightDirection = new Vector3(0, 0, 1);
	
	
	private Direction walkDir = Direction.Right;
	private RotationDirection rotateDir = RotationDirection.None;
	
	
	// Use this for initialization
	void Start () {
		startX = transform.position.x;
		endX = startX + travelDistance;
		
		if(endX < startX){
			float temp = startX;
			startX = endX;
			endX = temp;
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch(rotateDir){
		case RotationDirection.None:
			Vector3 movement = new Vector3 (metersPerSecond, 0, 0) * Time.deltaTime;	
		
			if(walkDir == Direction.Right)
				transform.position += movement;
			else if(walkDir == Direction.Left)
				transform.position -= movement;
		
			if(transform.position.x > endX){
				setPosX(endX);
				walkDir = Direction.Left;
				rotateDir = RotationDirection.Clockwise;
			}
			else if(transform.position.x < startX){
				setPosX(startX);
				walkDir = Direction.Right;
				rotateDir = RotationDirection.CounterClockwise;
			}
			break;
		case RotationDirection.Clockwise:
			Quaternion leftDirectionQuat = Quaternion.LookRotation (leftDirection);
			
			transform.rotation = Quaternion.Slerp(transform.rotation, leftDirectionQuat, Time.deltaTime * rotationSmoothing);
			
			if(transform.rotation == leftDirectionQuat)
				rotateDir = RotationDirection.None;
			
			break;
		case RotationDirection.CounterClockwise:
			Quaternion rightDirectionQuat = Quaternion.LookRotation (rightDirection);
			
			transform.rotation = Quaternion.Slerp(transform.rotation, rightDirectionQuat, Time.deltaTime * rotationSmoothing);
			
			if(transform.rotation == rightDirectionQuat)
				rotateDir = RotationDirection.None;
			
			break;
		default:
			DebugUtils.Assert(false);
			break;
		}
	}
	
	private void setPosX(float posX){
		Vector3 tempPosition = transform.position;
		tempPosition.x = posX;
		
		transform.position = tempPosition;
	}
}
