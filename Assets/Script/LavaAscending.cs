using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaAscending : MonoBehaviour {
	public float ascendSpeed=10f;

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (0f,ascendSpeed*Time.deltaTime,0f,Space.World);
	}
}
