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
                StartCoroutine(ChangeLvl());
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) && inTrigger == true)
        {
            player.canMove = false;
            StartCoroutine(ChangeLvl());
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
    IEnumerator ChangeLvl()
    {
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        player.transform.position = target.transform.position;
        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
        player.canMove = true;

    }
}
