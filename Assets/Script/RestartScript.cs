using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("reload", 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void reload()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
