using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour {
    bool used;
    GameObject lavaFloor;
    GameObject player;
    bool chaseOrNo = false;
    float chase = 0;
    // Use this for initialization
    void Start () {
        used = false;
        player = GameObject.Find("player");
        lavaFloor = GameObject.Find("Lava_distort");
    }

    private void Update()
    {
        if (transform.position.y < lavaFloor.transform.position.y - 10f)
        {
            Destroy(this.gameObject);
        }
       
        if ((transform.position - player.transform.position).magnitude < 25f)
        {
            chaseOrNo = true;
        }
        if (chaseOrNo)
        {
            if (chase <= 1)
            {
                chase += Time.deltaTime / 2f;
            }
            transform.position = Vector3.Lerp(transform.position, player.transform.position, chase);
        }

    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player"))
        {
            if (!used)
            {
				playSound ();
                PlayerHealth Playerhealth = GameObject.Find("player").GetComponent<PlayerHealth>();
                Playerhealth.health += 100;
                used = true;
                GameObject.Find("feedDisplay").GetComponent<feedDisplayScript>().display("+100 Hp");
                
                Destroy(this.gameObject);
            }
            
        }
		
	}
	void playSound(){

		AudioSource AS=GameObject.Find("player").GetComponentInChildren<AudioSource>();
		AS.Play ();
	}

}
