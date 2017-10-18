using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapScript : MonoBehaviour {
	GameObject lavaFloor;

    float timer = 0f;
    bool triggered = false;
    PlayerControl playControl;
	bool activate;
	Animation anime;
	AudioSource stabSound;
    // Use this for initialization
    void Start () {
		anime = GetComponentInChildren<Animation> ();
		lavaFloor = GameObject.Find ("Lava_distort");
        playControl = GameObject.Find("player").GetComponent<PlayerControl>();
		anime ["Up Down"].speed = 1.4f;
		activate = true;
		stabSound = GetComponent<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < lavaFloor.transform.position.y - 30f) {
			Destroy(this.gameObject);
		}
        if (triggered)
        {
            timer += Time.deltaTime;
			if (timer >= 3f||!anime.isPlaying)
            {
                triggered = false;
                timer = 0;
                playControl.freePlayer();
            }
        }
      
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
			if (activate) {
				stabSound.Play ();
				PlayerHealth playHealth=GameObject.Find("player").GetComponent<PlayerHealth>();
				playHealth.takeDmg (100f);
				anime.Play("Up Down");
				playControl.disablePlayer();
				triggered = true;

			}
			activate = false;
        }
    }

}
