using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDeathPoints : MonoBehaviour {
	pointCounter pc;
	Text tt;
	// Use this for initialization
	void Start () {
		tt = GetComponent<Text> ();
		pc = GameObject.Find ("Points").GetComponent<pointCounter>();

	}
	
	// Update is called once per frame
	void Update () {
		tt.text = "Your Score: " + Mathf.RoundToInt (pc.pointcount).ToString ();
	}
}
