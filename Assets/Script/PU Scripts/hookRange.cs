using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class hookRange : MonoBehaviour {
	bool used = false;
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
    // Update is called once per frame
    void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player"))
		{
				if (!used){
		        HookShot Hookshot = GameObject.Find("hookParent").GetComponent<HookShot>();
		        Hookshot.hookRange +=10;
				used = true;
				Destroy(this.gameObject);
                }
        }
    }
}