using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {

	public float health=500f;
	public Image dmgImage;
	public Text hp;
	public Slider slide;
	float length=1f;
	float start=0f;
	float end=0.5f;
	Color imgCol;
	// Use this for initialization
	void Start () {
		imgCol= dmgImage.color;
		slide.maxValue = health;
	}
	
	// Update is called once per frame
	void Update () {
		slide.value = health;
		hp.text = "HP: " + health.ToString();
	}

	public void takeDmg(float dmg){
		health -= dmg;
	
		StartCoroutine ("flash");

	}
	IEnumerator flash(){
		print ("gmg");
		for (float i = 0f; i <= 1f; i += Time.deltaTime * 1/length) {
			imgCol.a = Mathf.Lerp (end,start,i);
			dmgImage.color = imgCol;
		
			yield return null;
			imgCol.a =  start;
			dmgImage.color = imgCol;

		}

	}
}
