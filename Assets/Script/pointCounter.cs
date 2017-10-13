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
    // Use this for initialization
    private void Start()
    {
        pointcount = 0;
        SetCountText();
        
        trapsSpawnPoint[0] = 300;
        trapsSpawnPoint[1] = 200;
        trapCount = trapsSpawnPoint[0];

    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraY = player.transform.position.y;
        pointcount = Mathf.RoundToInt(cameraY);
        pointcount = pointcount / 3;
        SetCountText();
    }
    void SetCountText()
    {
        nextTrap.text = "Next Trap: " + trapCount.ToString();
        countText.text = "Points: " + pointcount.ToString();
        if (pointcount >= trapsSpawnPoint[0])
        {
            BearTrapSpawn bearTrapScript = GameObject.Find("EventManager").GetComponent<BearTrapSpawn>();
            bearTrapScript.spawningB = true;

        }
        if(pointcount >= trapsSpawnPoint[1])
        {
            TrapSpawnScript flyInBlock = GameObject.Find("EventManager").GetComponent<TrapSpawnScript>();
            flyInBlock.spawningF = true;

        }
    }
}
