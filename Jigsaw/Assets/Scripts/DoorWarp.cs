using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWarp : MonoBehaviour {
    public PlayerController player;

    public bool inTrigger;
    public GameObject target;
    public bool nobutton;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        inTrigger = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (nobutton)
        {
            if (inTrigger == true)
            {
                player.canMove = false;
                player.transform.position = target.transform.position;
                player.canMove = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) && inTrigger == true)
        {
            player.canMove = false;
            player.transform.position = target.transform.position;
            player.canMove = true;
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
