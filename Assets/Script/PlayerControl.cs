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
	public float maxPullVel=40f;
    public bool holdSpace=true;

    bool playerDisabled = false;
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
		rb.useGravity = true;
	}

	void FixedUpdate()
	{
		updateGravity ();
        hookTimer += Time.deltaTime;
		
		if ((transform.position - hookScript.hookTarget).magnitude <= 2||hookTimer>5||Input.GetKey ("space")) {
            hookScript.hookTravelling = false;
			hookScript.hookLanded = false;
			updateGravity (true);
            hookTimer = 0;
        }
		if (!playerDisabled)
		{
			basicMovement();
		}

		if (!hookScript.hookLanded) {
            if (!velReset)
            {
                velReset = true;
            }
			updateGravity (true);
			
		} else {
			if (velReset) {
				//rb.velocity = Vector3.zero;
				if (rb.velocity.magnitude > 0) {
					rb.velocity*=0.3f/rb.velocity.magnitude;
				}
				velReset = false;
				updateGravity (false);
			}
			hookTimer += Time.deltaTime;
			if (rb.velocity.magnitude <= maxPullVel) {
				rb.AddForce ((hookScript.hookTarget-transform.position)*pullSpeed);
			}


		}



	}
	bool anyInput(){
		if (Input.GetAxis ("Horizontal") != 0f || Input.GetAxis ("Vertical") != -0f || Input.GetKey ("space"))
			return true;


		return false;
	}
	void basicMovement(){

        if (holdSpace)
        {
            if (Input.GetKey("space"))
            {
                rb.AddForce(Vector3.up * thrustSpeed, ForceMode.Impulse);
            }

            if (Input.GetKey("c"))
                rb.AddForce(-Vector3.up * 2 * thrustSpeed, ForceMode.Impulse);
        }
		



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


    public void hookDetach()
    {
        hookScript.hookLanded = false;

    }
    public void disablePlayer()
    {
		gravityStatus = false;
        hookScript.hookLanded = false;
        playerDisabled = true;
        rb.velocity = Vector3.zero;
        hookScript.hookShotDisable = true;

    }

    public void freePlayer()
    {
		gravityStatus= true;
        playerDisabled = false;
        hookScript.hookShotDisable = false;

    }

    private void OnCollisionEnter(Collision other)
	{
		
		if(other.gameObject.CompareTag("trap")){
			hookScript.hookLanded = false;
			hookScript.hookTravelling = false;
            print("notmove");
			rb.velocity /= 2f;
		}

	}

	void updateGravity(bool flag){
		if (gravityStatus) {
			rb.useGravity = flag;
		} else {
			rb.useGravity = false;
		}
	}

	void updateGravity(){
		rb.useGravity = gravityStatus;
	}

}
