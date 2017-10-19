using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaAscending : MonoBehaviour {
	public float ascendSpeed=10f;
	public float countDown = 3f;
    public GameObject player;
    public bool enable = true;
    float speedChange = 10f;
    public GameObject points;
	public float dmgTick=3f;
    pointCounter pc;
	Rigidbody rb;
	float timer=0;
	bool playerIn=false;
    PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
        pc = points.GetComponent<pointCounter>();
		rb = GetComponent<Rigidbody> ();
		rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        playerHealth = player.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
       
            while (countDown > 0)
            {
                countDown -= Time.deltaTime;
                return;
            }
            speedChange = 10f + 0.3f * pc.pointcount / 50;

            transform.Translate(0f, ascendSpeed * Time.deltaTime, 0f, Space.World);
            if (player.transform.position.y - transform.position.y > 50)
            {
                ascendSpeed = speedChange + Mathf.Pow(1.3f, (player.transform.position.y - transform.position.y) / 10f);
            }
            else
            {
                ascendSpeed = speedChange;
            }
            if (playerIn)
            {
                timer += Time.deltaTime;
                if (timer >= dmgTick)
                {
                    dmgPlayer();
                    timer = 0f;
                }

            }

        if (player.transform.position.y < transform.position.y - 3)
        {
            player.transform.position = new Vector3 (player.transform.position.x, transform.position.y + 1, player.transform.position.z);
        }
        if (playerHealth.health <= 0)
        {
            this.enabled = false;
        }
		

	}

	private void OnCollisionEnter(Collision other){
		print("hitting");
		if(other.gameObject.CompareTag("Player")){
			dmgPlayer ();
		
		}
	}

	private void OnCollisionStay(Collision other){
		if(other.gameObject.CompareTag("Player")){
			playerIn = true;

		}
		
	}
	private void OnCollisionExit(Collision other){
		if(other.gameObject.CompareTag("Player")){
			playerIn = false;
		}

	}



	void dmgPlayer(){
		PlayerHealth playHealth=player.GetComponent<PlayerHealth>();
		playHealth.takeDmg(100f);
	}

}
