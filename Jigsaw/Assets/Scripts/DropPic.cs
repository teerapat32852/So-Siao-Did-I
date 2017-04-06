using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPic : MonoBehaviour {
    public PlayerController player;
    public GameObject pic;
    public bool intrigger=false;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(intrigger==true&& Input.GetKeyDown(KeyCode.E))
        {
            pic.SetActive(true);
        }
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            intrigger = true;
           
        }
    }
    void OnTriggerExit2D (Collider2D other)
    {
        if(other.name=="Player")
        {
            other.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            intrigger = false;
        }
    }
    void OnDestroy()
    {
        player.transform.GetChild(1).gameObject.SetActive(false);
    }
}
