using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookTravel : MonoBehaviour {
	public GameObject player;
	public GameObject Camera;
	public float lineOffset=2f;
	public bool right;
	Camera cam;
    HookShot parentt;
	LineRenderer line;
	HookShot hookShot;
	Vector3 offset;
	// Use this for initialization
	void Start () {
        parentt = GetComponentInParent<HookShot>();
		line = GetComponent<LineRenderer> ();
		hookShot = player.GetComponent<HookShot> ();
		cam = Camera.GetComponent<Camera> ();
		offset =  transform.position-player.transform.position ;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 camVec = cam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0)).direction.normalized;

		line.enabled = true;
		Vector3 sidePos = Vector3.Cross (Camera.transform.forward, Camera.transform.up);
		line.SetPosition (0,player.transform.position-camVec*lineOffset+sidePos.normalized*offset.magnitude*(right?-1f:1f));
		line.SetPosition (1, transform.position);
		 

	}
}
