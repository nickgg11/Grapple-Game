using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour {

	public float cd=2f;
	public GameObject player;
	public GameObject Camer;
	public float hookRange = 100;
	public Vector3 hookTarget;

	RaycastHit shootHit;
	
	private Camera cam;
	float timer=0f;
	Ray shootRay;

	public bool hookLanded=false;
	public bool hookTravelling=false;

	//
	float t=0;
	Vector3 startPosition;
	float timeToReachTarget=2f;
	AudioSource sound;
	//


	// Use this for initialization
	void Start () {
		
		cam = Camer.GetComponent <Camera>();
		sound = GetComponent<AudioSource> ();
	}
	
	void LateUpdate(){

	}

	void FixedUpdate () {
		


		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1")&&timer>cd&&!hookLanded) {
			hookTravelling = true;
			grapple ();

			timer = 0;
		}


		if (hookTravelling) {
			t += Time.deltaTime / timeToReachTarget;
			//transform.position = Vector3.Lerp (startPosition,shootHit.point,t);
			transform.Translate ((shootHit.point - startPosition) * 1f * Time.deltaTime, Space.World);
			if ((transform.position - shootHit.point).magnitude < 1) {
				hookTravelling = false;
				hookLanded = true;
			}




		} else if (hookLanded) {
			

		}else{
			
			transform.position = player.transform.position;
			transform.rotation = Quaternion.LookRotation (cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0)).direction);
		}
	}


	void grapple(){
		
		shootRay=cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		if (Physics.Raycast (shootRay, out shootHit, hookRange)) {
            if (shootHit.collider.CompareTag("cylinder"))
            {
                hookTarget = shootHit.point;
                startPosition = transform.position;
                sound.Play();
                return;
            }
            
			
		} 
		hookTravelling = false;
		
	}
}
