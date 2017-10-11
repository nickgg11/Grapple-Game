using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HookShot : MonoBehaviour {

	public float cd=2f;
	public GameObject player;
	public GameObject Camer;
	public float hookRange = 100;
	public Vector3 hookTarget;
    public Slider slide;
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
        slide.maxValue = cd;
        cam = Camer.GetComponent <Camera>();
		sound = GetComponent<AudioSource> ();
	}
	
	void LateUpdate(){

	}

	void FixedUpdate () {



        slide.value = cd-timer;
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1")&&timer>cd&&!hookLanded) {
			hookTravelling = true;
			grapple ();

			
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
        shootRay.origin = shootRay.origin + shootRay.direction.normalized;
		if (Physics.Raycast (shootRay, out shootHit, hookRange)) {
            if (shootHit.collider.CompareTag("cylinder"))
            {
                hookTarget = shootHit.point;
                startPosition = transform.position;
                sound.Play();
                timer = 0;
                return;
            }
            
			
		} 
		hookTravelling = false;
		
	}
}
