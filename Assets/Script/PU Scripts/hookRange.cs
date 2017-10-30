using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class hookRange : MonoBehaviour {
	bool used = false;
    GameObject lavaFloor;
    GameObject player;
    bool chaseOrNo = false;
    float chase = 0;
    // Use this for initialization
    void Start()
    {
        used = false;
        player = GameObject.Find("player");
        lavaFloor = GameObject.Find("Lava_distort");
    }
    private void Update()
    {
        if (transform.position.y < lavaFloor.transform.position.y - 10f)
        {
            Destroy(this.gameObject);
        }
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        if ((transform.position - player.transform.position).magnitude < 25f)
        {
            chaseOrNo = true;
        }
        if (chaseOrNo)
        {
            if (chase <= 1)
            {
                chase += Time.deltaTime / 2f;
            }
            transform.position = Vector3.Lerp(transform.position, player.transform.position, chase);
        }
    }
    // Update is called once per frame
    void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player"))
		{
				if (!used){
				PlayerControl pcontrol = GameObject.Find("player").GetComponent<PlayerControl >();
				pcontrol.pullSpeed +=0.5f;
				pcontrol.maxPullVel += 10f;
				used = true;
				Destroy(this.gameObject);
                }
        }
    }
}