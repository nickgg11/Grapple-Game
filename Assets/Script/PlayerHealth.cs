﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {
    public GameObject DeathMenu;
    public GameObject cursor;
	public float health=500f;
    public float maxHealth = 500f;
	public Image dmgImage;
	public Text hp;
	public Slider slide;
	float length=1f;
	float start=0f;
	float end=0.5f;
    bool dead = false;
	Color imgCol;
    PlayerControl pControl;

	//audio stuff
	public AudioClip deathAudio;
	AudioSource audio;
	//as

    // Use this for initialization
    void Start () {
		imgCol= dmgImage.color;
		slide.maxValue = health;
        pControl = this.gameObject.GetComponent<PlayerControl>();
        health = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
		slide.value = health;
		
        if (health <= 0)
        {
            pControl.disablePlayer();
            if (!dead)
            {
                dieProcedure();
                //Invoke("reload", 5f);
            }
            dead = true;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        hp.text = "HP: " + health.ToString()+" / "+maxHealth.ToString();

    }

	public void takeDmg(float dmg){
		health -= dmg;
		StartCoroutine ("flash");

	}


    void dieProcedure() {
        cursor.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DeathMenu.SetActive(true);
		audio=GameObject.Find ("EventManager").GetComponent<AudioSource> ();
		audio.clip = deathAudio;
		audio.Play ();
    }

    public void reload()
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
