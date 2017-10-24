using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointCounter : MonoBehaviour {
    public static Camera MainCamera;
    public Text countText;
    public GameObject player;
    public float[] trapsSpawnPoint=new float[7];
    private float cameraY;
    public float pointcount;
	float prevY;
    // Use this for initialization
    private void Start()
    {
        pointcount = 0f;
        //SetCountText();
		prevY = player.transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
		if(player.transform.position.y>prevY){
			
			pointcount += player.transform.position.y-prevY;
			prevY = player.transform.position.y;
		}
        
        
        
       

        SetCountText();
    }
    void SetCountText()
    {
		countText.text = "Points: " + Mathf.RoundToInt (pointcount).ToString();
        
        if(pointcount >= trapsSpawnPoint[0])
        {
            TrapSpawnScript flyInBlock = GameObject.Find("EventManager").GetComponent<TrapSpawnScript>();
            flyInBlock.spawningF = true;

        }
        if (pointcount >= trapsSpawnPoint[1])
        {
            BearTrapSpawn bearTrapScript = GameObject.Find("EventManager").GetComponent<BearTrapSpawn>();
            bearTrapScript.spawningB = true;

        }

        if (pointcount >= trapsSpawnPoint[2])
        {
            HalfCoverTrapSpawn hfSpawn = GameObject.Find("EventManager").GetComponent<HalfCoverTrapSpawn>();
            hfSpawn.spawningH = true;

        }

    }
}
