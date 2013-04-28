using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {
	
	GameObject ovrPlayerControllerGO;
	
	void Start () {
		ovrPlayerControllerGO = GameObject.Find("OVRPlayerController");
	}
	
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			GameObject shuriken = (GameObject) Instantiate(Resources.Load("Shuriken"));
			shuriken.transform.position = ovrPlayerControllerGO.transform.position;
		}
	}
}
