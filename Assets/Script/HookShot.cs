using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HookShot : MonoBehaviour {
	public GameObject clonePrefab;
    public GameObject redClone;
    public float cd=2f;
	public GameObject player;
	public GameObject Camer;
	public float hookRange = 100;
	public Vector3 hookTarget;
    public Slider slide;
    public float hookSpeeds = 1f;
	RaycastHit shootHit;
	RaycastHit blueHit;
	RaycastHit prevHit;

	GameObject clone;
    public bool hookShotDisable = false;
	private Camera cam;
	float timer=0f;
	Ray shootRay;
	Ray blueRay;
	public bool hookLanded=false;
	public bool hookTravelling=false;
    bool targetValid = false;
	//
	float t=0;
	Vector3 startPosition;
	float timeToReachTarget=2f;
	AudioSource sound;
    //
 
    public float distance;

	// Use this for initialization
	void Start () {
        slide.maxValue = cd;
        cam = Camer.GetComponent <Camera>();
		sound = GetComponent<AudioSource> ();
		timer = cd;
       
	}
	
	void LateUpdate(){

	}

	void FixedUpdate () {
        


        slide.value = cd-timer;
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1")&&timer>cd&&!hookLanded&&!hookShotDisable) {

            // if (blueHit.collider.gameObject.layer != LayerMask.NameToLayer("cylinder"))
            //   {
            //       timer = 2f;
            //  }
            //  else
            //  {
            if (targetValid)
            {
                grapple();
            }
           // } 
		}


		if (hookTravelling) {

            //transform.position = Vector3.Lerp (startPosition,shootHit.point,t);
            Vector3 destination = blueHit.point;
			transform.Translate ((destination - startPosition) * hookSpeeds * Time.deltaTime, Space.World);

            if ((transform.position - destination).magnitude < 1) {
            
				hookTravelling = false;
				hookLanded = true;
			}

		} else if (hookLanded) {
        }
        else{
			blueIndicator ();
			transform.position = player.transform.position;
			transform.rotation = Quaternion.LookRotation (cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0)).direction);
		}
	}

	void blueIndicator(){
        Destroy(clone);
        blueRay =cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		blueRay.origin = blueRay.origin + blueRay.direction.normalized;
        if (Physics.Raycast(blueRay, out blueHit, hookRange))
        {
            targetValid = true;
            //Destroy(clone);
            //if (blueHit.collider.gameObject.layer == LayerMask.NameToLayer("cylinder"))
            if (blueHit.collider.gameObject.tag.Contains("Wall"))
            {
                Vector3 temppp = blueHit.collider.gameObject.transform.position;
                clone = Instantiate(clonePrefab, blueHit.collider.gameObject.transform);
                temppp.y = 0;
                //clone.transform.Translate (-temppp.normalized * 2f);
                MeshFilter mesh = clone.GetComponent<MeshFilter>();
                mesh = blueHit.collider.gameObject.GetComponent<MeshFilter>();
                return;
            }

            targetValid = false;

        }
        else
        {
            targetValid = false;
        }

        //red indicator
        if (Physics.Raycast(blueRay, out blueHit, 1000f))
        {
            Vector3 temppp = blueHit.collider.gameObject.transform.position;
            clone = Instantiate(redClone, blueHit.collider.gameObject.transform);
            MeshFilter mesh = clone.GetComponent<MeshFilter>();
            mesh = blueHit.collider.gameObject.GetComponent<MeshFilter>();
            

        }

    }

	/*
	void grapple(){
		
		shootRay=cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		shootRay.origin = shootRay.origin + shootRay.direction.normalized;

		if (Physics.Raycast (shootRay, out shootHit, hookRange)) {
			


            if (shootHit.collider.gameObject.layer== LayerMask.NameToLayer("cylinder"))
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
*/
	void grapple(){ 
       
        hookTarget = blueHit.point;
        startPosition = transform.position;
        distance = (hookTarget - startPosition).magnitude;
        hookTravelling = true;
        sound.Play();
        timer = 0;
        return;
	}


}
