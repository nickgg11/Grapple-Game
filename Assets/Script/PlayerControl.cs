using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	// Use this for initialization
	public float slowValue=6f;
	public float Initialspeed;
	public float thrustSpeed=2.5f;
	public GameObject hook;
	public GameObject Camera;
	public float dashSpeed = 5f;
	public float pullSpeed=2f;




	private bool gravityStatus = true;
	HookShot hookScript;
	private Rigidbody rb;
	private int count;

	float hookTimer =0;
	bool velReset=false;
	Vector3 vec;
	private float speed;
	void Start()
	{
		speed = Initialspeed;


		rb = GetComponent<Rigidbody>();
		count = 0;
		hookScript = hook.GetComponent<HookShot> ();
		rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

	}

	void FixedUpdate()
	{
		print (hookTimer);
		if ((transform.position - hookScript.hookTarget).magnitude <= 2||hookTimer>5) {
			hookScript.hookLanded = false;

		}
		if (!hookScript.hookLanded) {
			rb.useGravity = true;
			basicMovement ();
			velReset = true;
			hookTimer = 0;
		} else {
			if (velReset) {
				rb.velocity = Vector3.zero;
				velReset = false;
				rb.useGravity = false;
			}
			hookTimer += Time.deltaTime;
			rb.AddForce ((hookScript.hookTarget-transform.position)*pullSpeed);

		}



	}
	void basicMovement(){
		if (Input.GetKey ("space")) {
			rb.AddForce (Vector3.up * thrustSpeed, ForceMode.Impulse);
		}

		if (Input.GetKey("c"))
			rb.AddForce(-Vector3.up * 2*thrustSpeed, ForceMode.Impulse);



		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = Initialspeed*6;
		} else {
			speed = Initialspeed;
		}

		float moveHorizontal = -Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		//  Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		Vector3 cameraVec = new Vector3(Camera.transform.forward.x,0, Camera.transform.forward.z);
		Vector3 movement = Vector3.ProjectOnPlane(Camera.transform.forward,Vector3.up).normalized* moveVertical     +   Vector3.Cross(cameraVec, Vector3.up).normalized*moveHorizontal*0.8f;

		if(moveHorizontal!=0||moveVertical!=0){
			rb.AddForce(movement * speed);
		}
	}





	private void OnTriggerEnter(Collider other)
	{
		
	}

}
