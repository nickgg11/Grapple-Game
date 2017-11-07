using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOptionScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<Toggle>().isOn)
        {
            AudioListener.volume = 1.0f;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

	public void musicOnorOff(){
		print ("sound chagned");
		if (this.gameObject.GetComponent<Toggle> ().isOn) {
			AudioListener.volume = 1.0f;
		} else {
			AudioListener.volume = 0;
		}

	}
	
}
