using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaAscending : MonoBehaviour {
	public float ascendSpeed=10f;
    public GameObject player;
    float speedChange = 10f;
    public GameObject points;
    pointCounter pc;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
        pc = points.GetComponent<pointCounter>();
		rb = GetComponent<Rigidbody> ();
		rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        speedChange = 10f+0.3f*pc.pointcount / 50;
        
		transform.Translate (0f,ascendSpeed*Time.deltaTime,0f,Space.World);
        if (player.transform.position.y-transform.position.y>50)
        {
            ascendSpeed = speedChange+Mathf.Pow(1.3f,(player.transform.position.y - transform.position.y)/10f);
        }
        else
        {
            ascendSpeed = speedChange;
        }
	}
}
