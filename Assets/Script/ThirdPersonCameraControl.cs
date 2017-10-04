using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonCameraControl : MonoBehaviour {


	public GameObject player;
	public float speedH=2f;
	public float speedV = 2f;


	private float yaw=0f;
	private float pitch =0f;
	private Vector3 offset;
	// Use this for initialization
	void Start () {

		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position;
		yaw += speedH * Input.GetAxis ("Mouse X");
		pitch -= speedV * Input.GetAxis ("Mouse Y");
		
		transform.position = player.transform.position + offset;

        if (Mathf.Abs(pitch )> 75)
        {
            pitch = pitch / Mathf.Abs(pitch) * 75;
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        }

    }


}
