using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderGenerate : MonoBehaviour {
    public float generateSpeed=0.2f;
	public float initialSpawn=10f;
    public float layersHigherThan=30;
    public GameObject layer;
    public GameObject player;
    float timer = 0f;
    float height = 0f;

	// Use this for initialization
	void Start () {
		generate (initialSpawn);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float temp = height-player.transform.position.y;
        generate(layersHigherThan-(temp/10));
        
	}

	void generate(float k){
		for(int i = 0; i < k; i++)
		{
			Vector3 pos = new Vector3(0, height, 0);
			Quaternion rotation = new Quaternion(0, 0, 0, 1);
			Instantiate(layer, pos, rotation);
			height += 10;
			timer = 0;
		}
	}
}
