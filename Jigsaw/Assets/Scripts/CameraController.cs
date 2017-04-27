using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public PlayerController player;
    public GameObject nextPosition;
    public GameObject oldPosition;
    public bool isFollowing;
    public bool shifting = false;
    public bool shiftingback = false;
    public bool free = false;
   // bool change = false;
    public float xOffset;
    public float yOffset;
    public float shift;
    public float shiftSpeed = .6f;
    public float t = 0;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
        //isFollowing =true;
    }
	
	// Update is called once per frame
	void Update () {
        //nextPosition.transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset + shift, transform.position.z);
        //oldPosition.transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
        //t += Time.deltaTime * (Time.timeScale / shiftSpeed);
        if (shifting == true)
        {
            if(t<1)
            t += Time.deltaTime * (Time.timeScale / shiftSpeed); 
            transform.position = Vector3.Lerp(transform.position, nextPosition.transform.position, t);

        }
        else if (shiftingback == true)
        {
            if(t<1)
                t += Time.deltaTime * (Time.timeScale / shiftSpeed);
            transform.position = Vector3.Lerp(transform.position, oldPosition.transform.position, t);

        }
   
        else
        {
            t = 0.0f;
            if (isFollowing == false)
            {


                if (free == false)
                {
                    transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset + shift, transform.position.z);
                    // transform.position = nextPosition.transform.position;
                }
                else
                    return;

            }
            else
            {
                if (isFollowing == true)
                    transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
                // transform.position = oldPosition.transform.position;
            }
        }
    }
}
