using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour {
    
    public Material[] materials;

    Renderer[] rend;
	GameObject EventManager;
	GameObject lavaFloor;
	GameObject[] Children=new GameObject[10];

    // Use this for initialization
    void Start () {
		EventManager=GameObject.Find("EventManager");
		BearTrapSpawn bearTrapSpawnScript = EventManager.GetComponent<BearTrapSpawn> ();
		lavaFloor = GameObject.Find ("Lava_distort");
        

        rend = GetComponentsInChildren<Renderer>();

        for (int i=0;i< rend.Length;i++)
         {           
            Children[i]=(rend[i].gameObject);
            rend[i].material = materials[Random.Range(0, 4)]; 
         }

		for (int i=0;i< Children.Length;i++)
		{           
			if (Random.Range (0, 100) <= bearTrapSpawnScript.BearTrapSpawnRate) {
				Vector3 temp = (transform.position - Children [i].transform.position) * 0.06f + Children [i].transform.position;
				bearTrapSpawnScript.spawnBearTrap (temp,Children[i].transform.rotation);
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
