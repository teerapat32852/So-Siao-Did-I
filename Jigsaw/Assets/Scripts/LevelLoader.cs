using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour {
    public bool inTrigger;
    public string levelToLoad;
	// Use this for initialization
	void Start () {
        inTrigger = false;

	}
	
	// Update is called once per frame
	void Update () {
	 if(Input.GetKeyDown(KeyCode.E)&& inTrigger==true)
        {
            SceneManager.LoadScene(levelToLoad);
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Player")
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
