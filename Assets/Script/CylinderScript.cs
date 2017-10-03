using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour {
    public float destroyTime = 2f;
    float timer = 0f;
    public Material[] materials;
    Renderer[] rend;
    
   GameObject[] Children=new GameObject[10];
    // Use this for initialization
    void Start () {
        int counter=1;
        rend = GetComponentsInChildren<Renderer>();

         for (int i=0;i< rend.Length;i++)
         {
            print(counter);
            counter++;
            Children[i]=(rend[i].gameObject);
            rend[i].material = materials[Random.Range(0, 3)]; 
         }


        Destroy(this.gameObject,destroyTime);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;

        

	}
}
