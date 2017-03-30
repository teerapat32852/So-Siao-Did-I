using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrancisRun : MonoBehaviour {
    public GameObject trigger;
    public PlayerController player;
    bool movetopos = false;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}

    void Awake ()
    {
        
    }
    // Update is called once per frame
    public float period = 0.0f;
    public int step = 0;
    void Update()
    {
        if (gameObject.activeSelf&&!movetopos)
        {
            movetopos = true;
            player.canMove = false;
            transform.position = new Vector3(player.transform.position.x - 10.2f, player.transform.position.y, player.transform.position.z);
        }

        if (period > .01&&step<70)
        {
            transform.position = new Vector3(transform.position.x + .1f, transform.position.y , transform.position.z);
            step++;
            period = 0;
            if (step==69)
                trigger.SetActive(true);
        }
        period += UnityEngine.Time.deltaTime;
    }
}
