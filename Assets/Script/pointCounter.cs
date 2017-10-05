using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointCounter : MonoBehaviour {
    public static Camera MainCamera;
    public Text countText;
    public GameObject player;
    public bool[] traps;
    private float cameraY;
    private int pointcount;
	// Use this for initialization
	private void Start () {
        pointcount = 0;
        SetCountText();
        traps = new bool[8];
        traps[0] = false;
        traps[1] = false;
        traps[2] = false;
        traps[3] = false;
        traps[4] = false;
        traps[5] = false;
        traps[6] = false;
        traps[7] = false;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        cameraY = player.transform.position.y;
            pointcount = Mathf.RoundToInt(cameraY);
        pointcount = pointcount / 3;
        SetCountText();
    }
    void SetCountText()
    {
        countText.text = "Points: " + pointcount.ToString();
        if (pointcount >= 500)
        {
            
        }
    }
}
