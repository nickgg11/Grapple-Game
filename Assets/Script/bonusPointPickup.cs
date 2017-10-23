using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusPointPickup : MonoBehaviour {
	bool used = false;
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player"))
			{
				if (!used)
				{
		pointCounter Playerpoints = GameObject.Find("Canvas").GetComponent<pointCounter>();
		Playerpoints.pointcount +=600;
					used = true;
				Destroy (this.gameObject);
			}

}
			}
}