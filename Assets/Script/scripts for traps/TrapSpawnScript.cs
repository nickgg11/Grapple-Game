﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawnScript : MonoBehaviour {
    public GameObject[] traps;
    public GameObject player;
	public float spawnFrequency = 10;
    public bool spawningF = false;
    Vector3 pos;
    float timer = 0f;
    // Use this for initialization
    void Start()
    {
        pos = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawningF)
        {
            timer += Time.deltaTime;
            if (timer > 3f && pos.y < player.transform.position.y)
            {
				if (Random.Range (0, 100) < spawnFrequency) {
					pos.z = Random.Range(60, 100);
					if (Random.Range(0, 2) == 1)
					{
						pos.z *= -1f;
					}
					pos.x = Random.Range(60, 100);
					if (Random.Range(0, 1) == 1)
					{
						pos.x *= -1f;
					}

					pos.y = player.transform.position.y + Random.Range(80,150);
					Quaternion rotation = new Quaternion(0, 0, 0, 1);
					Instantiate(traps[0], pos, rotation);
				}
                timer = 0;
            }
        }
    }
}
