﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthPU : MonoBehaviour {
	bool used;
	GameObject lavaFloor;
	// Use this for initialization
	void Start () {
		used = false;
		lavaFloor = GameObject.Find("Lava_distort");
	}

	private void Update()
	{
		if (transform.position.y < lavaFloor.transform.position.y - 10f)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player"))
		{
			if (!used)
			{
				PlayerHealth Playerhealth = GameObject.Find("player").GetComponent<PlayerHealth>();
				Playerhealth.maxHealth += 50f;
                Playerhealth.health += 50f;
                used = true;
				Destroy(this.gameObject);
			}

		}

	}
}