using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointCounter : MonoBehaviour {
    public static Camera MainCamera;
    public Text countText;
    public GameObject player;
    public Text nextTrap;
    public float[] trapsSpawnPoint=new float[7];
    private float cameraY;
    public int pointcount;
    public float trapCount;
	public Text newTrap;
	int trapNum=0;
	float Ttimer=0f;
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
        pointcount = Mathf.RoundToInt(cameraY);
		pointcount = pointcount / 3;
  

        trapCount = trapsSpawnPoint[trapNum] - pointcount;
        if (trapCount <= 0) 
		{
            if (trapNum < trapsSpawnPoint.Length-1)
            {
                trapNum++;
            }
			
            Ttimer = 0f;
        }

        Ttimer += Time.deltaTime;
        if (Ttimer < 3)
        {
            newTrap.enabled = true;
        }
        else
        {
            newTrap.enabled = false;
        }


        SetCountText();
    }
    void SetCountText()
    {
        nextTrap.text = "Next Trap: " + trapCount.ToString();
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

    }
}
