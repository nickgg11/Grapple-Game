using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneLoader : MonoBehaviour {


    public void loadScene1()
    {
        print("load");
        SceneManager.LoadScene("scene1", LoadSceneMode.Single);

    }
    public void exit()
    {
        Application.Quit();
    }
}