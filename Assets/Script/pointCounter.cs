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
    public int pointcount;
    // Use this for initialization
    private void Start()
    {
        pointcount = 0;
        //SetCountText();
		 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraY = player.transform.position.y;
        if(cameraY>pointcount*3)
        pointcount += Mathf.RoundToInt(cameraY-pointcount/3);
       

        SetCountText();
    }
    void SetCountText()
    {
        countText.text = "Points: " + pointcount.ToString();
        
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
