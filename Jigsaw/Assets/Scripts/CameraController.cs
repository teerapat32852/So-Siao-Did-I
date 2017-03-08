using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public PlayerController player;
    public bool isFollowing;
    
    bool change = false;
    public float xOffset;
    public float yOffset;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
       //isFollowing =true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFollowing == false)
            transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset -4, transform.position.z);
        else
        if (isFollowing==true)
            transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
    }
}
