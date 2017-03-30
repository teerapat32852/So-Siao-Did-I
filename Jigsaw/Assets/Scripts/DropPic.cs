using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPic : MonoBehaviour {
    public GameObject pic;
    public bool intrigger=false;
	// Use this for initialization
	void Start () {
		
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
            intrigger = true;
           
        }
    }
    void OnTriggerExit2D (Collider2D other)
    {
        if(other.name=="Player")
        {
            intrigger = false;
        }
    }
}
