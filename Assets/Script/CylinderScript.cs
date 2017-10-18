﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour {
    
    public Material[] materials;
    public string[] tagName;

    Renderer[] rend;
	GameObject lavaFloor;
	GameObject[] Children=new GameObject[10];

    // Use this for initialization
    void Start () {
		
		BearTrapSpawn bearTrapSpawnScript = GameObject.Find("EventManager").GetComponent<BearTrapSpawn> ();
		lavaFloor = GameObject.Find ("Lava_distort");
        

        rend = GetComponentsInChildren<Renderer>();

        //assign different wall texture and tags them
        for (int i=0;i< rend.Length;i++)
         {
            Children[i]=(rend[i].gameObject);
            int temp = Random.Range(0, materials.Length);
            rend[i].material = materials[temp];
            Children[i].tag = tagName[temp];
         }

        //spawn bear trap
		for (int i=0;i< Children.Length;i++)
		{           
			if (Random.Range (0, 100) <= bearTrapSpawnScript.BearTrapSpawnRate) {
				Vector3 temp = (transform.position - Children [i].transform.position) * 0.06f + Children [i].transform.position;
                Quaternion quat = Quaternion.LookRotation(new Vector3(0,temp.y,0)-temp, Vector3.up);
                bearTrapSpawnScript.spawnBearTrap (temp,quat);
			}


		}

       
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y < lavaFloor.transform.position.y - 10f) {
			Destroy(this.gameObject);
		}

        

	}
}
