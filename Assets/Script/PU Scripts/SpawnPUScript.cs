using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPUScript : MonoBehaviour {

    public GameObject[] PU = new GameObject[5];
    public GameObject player;
    float timer = 5f;
    public float spawnFrequency = 10f;
    Vector3 pos;
    float prevy;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 5f && pos.y < player.transform.position.y)
        {
            timer = 0;
            if (Random.Range(0, 100) < spawnFrequency)
            {
                pos.z = Random.Range(-30, 30);
               
                pos.x = Random.Range(-30, 30);
                
               

                pos.y = player.transform.position.y + 500f;
                Quaternion rotation = new Quaternion(45, 45, 45, 1);
                Instantiate(PU[Random.Range(0,5)], pos, rotation);
            }
           
        }
    }
}
