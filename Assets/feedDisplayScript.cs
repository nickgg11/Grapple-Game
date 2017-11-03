using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class feedDisplayScript : MonoBehaviour {
    public Text tt;
    
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void display(string str)
    {
        tt.text = str;
        Invoke("remove",2f);

    }

    void remove()
    {
        tt.text = "";
    }
}
