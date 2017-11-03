using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOptionScript : MonoBehaviour {
	AudioListener AL ;
	// Use this for initialization
	void Start () {
		AL = GameObject.Find ("Main Camera1").GetComponent<AudioListener> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void musicOnorOff(){
		print ("sound chagned");
		AL.enabled = this.gameObject.GetComponent<Toggle>().isOn;
	}
	
}
