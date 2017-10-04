using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderGenerate : MonoBehaviour {
    public float generateSpeed=0.2f;
	public float initialSpawn=10f;
    public GameObject layer;
    float timer = 0f;
    float height = 0f;

	// Use this for initialization
	void Start () {
		initialLayerBuild ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;

        if (timer >=generateSpeed)
        {
            Vector3 pos = new Vector3(0,height,0);
            Quaternion rotation = new Quaternion(0,0,0,1);
            Instantiate(layer,pos,rotation);
            height += 10;
            timer = 0;
        }
	}

	void initialLayerBuild(){
		for(int i = 0; i < initialSpawn; i++)
		{
			Vector3 pos = new Vector3(0, height, 0);
			Quaternion rotation = new Quaternion(0, 0, 0, 1);
			Instantiate(layer, pos, rotation);
			height += 10;
			timer = 0;
		}
	}
}
