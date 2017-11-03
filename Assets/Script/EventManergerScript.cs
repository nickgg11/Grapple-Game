using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManergerScript : MonoBehaviour {
	public GameObject menuu;
	// Use this for initialization
	void Start () {
		disableCursor ();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			print ("escape");
			pauseGame ();
			
		}
	}

	public void disableCursor(){
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void pauseGame(){
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		GameObject.Find ("player").GetComponent<PlayerControl> ().disablePlayer ();
		GameObject.Find ("Lava_distort").GetComponent<LavaAscending> ().enabled = false;
		//GameObject.Find ("hookParent").GetComponent<HookShot
		menuu.SetActive(true);


	}

	public void resumeGame(){
		disableCursor ();
		GameObject.Find ("player").GetComponent<PlayerControl> ().freePlayer ();
		//GameObject.Find ("hookParent").GetComponent<HookShot
		menuu.SetActive(false);
		GameObject.Find ("Lava_distort").GetComponent<LavaAscending> ().enabled = true;
	}
}
