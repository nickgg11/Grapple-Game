using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfCoverTrapScript : MonoBehaviour {

    GameObject lavaFloor;
    void Start()
    {
        lavaFloor = GameObject.Find("Lava_distort");
    }


    void Update()
    {
        if (transform.position.y < lavaFloor.transform.position.y - 50f)
        {
            Destroy(this.gameObject);
        }
      

    }
}
