using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {

	public float health=500f;
	public Image dmgImage;
	public Text hp;
	public Slider slide;
	float length=1f;
	float start=0f;
	float end=0.5f;
    bool dead = false;
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
        if (health <= 0)
        {
            if (!dead)
            {
                Invoke("dieProcedure", 5f);
            }
            dead = true;
        }

	}

	public void takeDmg(float dmg){
		health -= dmg;
       
		StartCoroutine ("flash");

	}
    void dieProcedure()
    {

       
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

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
