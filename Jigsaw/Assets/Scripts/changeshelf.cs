using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeshelf : MonoBehaviour {

    public bool inTrigger;
    public GameObject othershelf;
    // Use this for initialization
    void Start()
    {
        inTrigger = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger == true)
        {
            
            othershelf.SetActive(true);
            gameObject.SetActive(false);
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
