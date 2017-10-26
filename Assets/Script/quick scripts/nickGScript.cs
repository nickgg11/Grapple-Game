using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nickGScript : MonoBehaviour {
    public GameObject lava;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = lava.transform.position + Vector3.up * 400f;
	}
}
