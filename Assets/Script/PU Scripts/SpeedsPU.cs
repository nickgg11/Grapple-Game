using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedsPU : MonoBehaviour {

	

    bool used;
    GameObject lavaFloor;
    // Use this for initialization
    void Start()
    {
        used = false;
        lavaFloor = GameObject.Find("Lava_distort");
    }

    private void Update()
    {
        if (transform.position.y < lavaFloor.transform.position.y - 10f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {

            if (!used)
            {
                print("pu");
                HookShot pHook = GameObject.Find("hookParent").GetComponent<HookShot>();
                pHook.hookSpeeds += 0.5f;
                
                used = true;
                Destroy(this.gameObject);
            }

        }

    }
}



