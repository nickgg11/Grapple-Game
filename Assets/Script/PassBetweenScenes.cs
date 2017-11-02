using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PassBetweenScenes : MonoBehaviour {

    bool musicOn;
    bool changing = false;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);


    }

   
    // Update is called once per frame
    
    void Update () {
  	}
    public void sceneChanged()
    {
        musicOn = GameObject.Find("Music Toggle").GetComponent<Toggle>().isOn;
        Invoke("musicOnOrOff", 0.1f);

    }
    void musicOnOrOff()
    {
        AudioSource AS = GameObject.Find("EventManager").GetComponent<AudioSource>();
        AS.enabled = musicOn;

    }
}
