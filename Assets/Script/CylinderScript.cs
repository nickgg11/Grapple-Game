using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour {
    
    public Material[] materials;
    Renderer[] rend;
    
	GameObject lavaFloor;
	GameObject[] Children=new GameObject[10];
    // Use this for initialization
    void Start () {

		lavaFloor = GameObject.Find ("Lava_distort");
        

        rend = GetComponentsInChildren<Renderer>();

         for (int i=0;i< rend.Length;i++)
         {           
            Children[i]=(rend[i].gameObject);
            rend[i].material = materials[Random.Range(0, 4)]; 
         }


       
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y < lavaFloor.transform.position.y - 10f) {
			Destroy(this.gameObject);
		}

        

	}
}
