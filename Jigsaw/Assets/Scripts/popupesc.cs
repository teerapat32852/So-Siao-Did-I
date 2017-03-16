using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupesc : MonoBehaviour {
    private PlayerController player;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            player.canMove = true;
            gameObject.SetActive(false);
        }
    }
}
