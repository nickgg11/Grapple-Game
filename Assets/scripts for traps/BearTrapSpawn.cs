using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapSpawn : MonoBehaviour {
	public GameObject bearTrap;
	public float BearTrapSpawnRate=10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void spawnBearTrap(Vector3 pos,Quaternion quat){
		Instantiate (bearTrap, pos, quat);

	}
}
