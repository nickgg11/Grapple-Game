using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPUScript : MonoBehaviour
{

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

        print("pu");
        if (other.CompareTag("Player"))
        {
            if (!used)
            {
                pointCounter Playerpoints = GameObject.Find("Points").GetComponent<pointCounter>();
                Playerpoints.pointcount += 300;
                used = true;
                Destroy(this.gameObject);
            }

        }

    }
}

