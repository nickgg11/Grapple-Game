using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyInBlock : MonoBehaviour {
    GameObject player;

    public float flyInSpeed = 1f;
    Rigidbody rb;
    Vector3 flyInDirection;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        player= GameObject.Find("player");
        Vector3 temp = player.transform.position;
        temp.y = transform.position.y;
        flyInDirection = temp - transform.position;
        flyInDirection.Normalize();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (player.transform.position.y - transform.position.y < 20f)
        {
          //  rb.AddForce(flyInDirection*flyInSpeed,ForceMode.Impulse);
			rb.AddForce((player.transform.position-transform.position).normalized*flyInSpeed,ForceMode.Impulse);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

	}
}
