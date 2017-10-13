using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapScript : MonoBehaviour {
	GameObject lavaFloor;

    float timer = 0f;
    bool triggered = false;
    PlayerControl playControl;
    // Use this for initialization
    void Start () {
		lavaFloor = GameObject.Find ("Lava_distort");
        playControl = GameObject.Find("player").GetComponent<PlayerControl>();
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < lavaFloor.transform.position.y - 30f) {
			Destroy(this.gameObject);
		}
        if (triggered)
        {
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                triggered = false;
                timer = 0;
                playControl.freePlayer();
            }
        }
      
        
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            playControl.disablePlayer();
            triggered = true;
        }
    }

}
