using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneLoader : MonoBehaviour {
	Scene ss;
	public Sprite newSprite;
	void OnGUI()
	{
		/*print ("load start");
		ss = SceneManager.GetSceneByName ("scene1");
		SceneManager.LoadSceneAsync (ss.buildIndex);*/
		if(GUI.Button(new Rect (Screen.width /2 -35, 50 ,60 ,60), "Play"))
		{
			SceneManager.LoadScene("scene1", LoadSceneMode.Single);
    	}
		if(GUI.Button(new Rect (Screen.width /2 -35, 250 ,60 ,60), "Exit"))
		{
			Application.Quit ();
		}
		if(GUI.Button(new Rect (Screen.width /2 -35, 150 ,80 ,60), "Highscore"))
		{
			SceneManager.LoadScene("scene3", LoadSceneMode.Single);	
		}
	}
}