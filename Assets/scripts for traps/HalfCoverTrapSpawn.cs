using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfCoverTrapSpawn : MonoBehaviour {
    
    public GameObject hcTrap;
    public GameObject doorTrap;
    public float frequency=100;
    public GameObject player;
    public float distanceBetween = 200f;
    float lastY=0;
    public bool spawningH=false;

    float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (spawningH)
        {
            timer += Time.deltaTime;
            if (Random.Range(0, 100) <= frequency && timer > 4f && player.transform.position.y + 1000f > lastY + distanceBetween)
            {
                timer = 0;
                Vector3 temp = new Vector3(Random.Range(-75, 75), 0, Random.Range(-75, 75)).normalized;
                Vector3 pos = temp * Random.Range(20, 60);
                pos.y += player.transform.position.y + 1000f;
                lastY = pos.y;
                Quaternion quat = Quaternion.LookRotation(temp, Vector3.up);

                if (Random.Range(0, 100) < 50)
                {
                    SpawnHalf(pos,quat);
                }
                else
                {
                    SpawnDoor(new Vector3(0,pos.y,0), quat);
                }


            }

        }
        

	}

    void SpawnHalf(Vector3 pos, Quaternion quat)
    {
        Instantiate(hcTrap, pos, quat);

    }



    void SpawnDoor(Vector3 pos, Quaternion quat)
    {
        Instantiate(doorTrap, pos, quat);
    }



}
