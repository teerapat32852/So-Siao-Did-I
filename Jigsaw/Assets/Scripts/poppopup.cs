﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poppopup : MonoBehaviour {
    public bool inTrigger;
    public GameObject panel;
    public TextBoxManager theTextBox;
    private PlayerController player;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        theTextBox = FindObjectOfType<TextBoxManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (theTextBox.isActive == true)
            return;
        if (Input.GetKeyDown(KeyCode.E) && inTrigger == true)
        {
            player.canMove = false;
            panel.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTrigger = false;
        }
    }
}
