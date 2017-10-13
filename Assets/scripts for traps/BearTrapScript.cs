using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapScript : MonoBehaviour {
	GameObject lavaFloor;

	// Use this for initialization
	void Start () {
		lavaFloor = GameObject.Find ("Lava_distort");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < lavaFloor.transform.position.y - 10f) {
			Destroy(this.gameObject);
		}
	}
}
