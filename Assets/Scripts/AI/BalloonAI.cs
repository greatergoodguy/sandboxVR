using UnityEngine;
using System.Collections;

public class BalloonAI : MonoBehaviour {
	
	public float floatRate = 1.0f;
	
	void Start () {}
	
	void Update () {
		Vector3 movement = new Vector3 (0, floatRate, 0) * Time.deltaTime;	
		transform.Translate(movement);
	}
}
