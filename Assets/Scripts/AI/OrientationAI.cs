using UnityEngine;
using System.Collections;

public class OrientationAI : MonoBehaviour {
	private GameObject playerControllerGO;
	
	void Start () {
		playerControllerGO = GameObject.Find("OVRPlayerController");
	}
	
	void Update () {
		Vector3 point = playerControllerGO.transform.position;
		point.y = transform.position.y;
		transform.LookAt(point);
	}
}
