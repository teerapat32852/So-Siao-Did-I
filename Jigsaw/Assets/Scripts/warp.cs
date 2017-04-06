using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour {
    public PlayerController player;
    public GameObject warppoint;
    public GameObject frantrigger;
    public GameObject gabtrigger;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            player.gameObject.transform.position = warppoint.transform.position;
            frantrigger.SetActive(true);
            gabtrigger.SetActive(true);
        }
    }
}
