using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LockedDoor : MonoBehaviour {

    public bool inTrigger;
    public static bool unlocked;
    public string levelToLoad;
    public GameObject guessmenu;
    private GuessController guesspanel;
    // Use this for initialization
    void Start()
    {
        inTrigger = false;
        unlocked = false;
        guesspanel = gameObject.GetComponent<GuessController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger == true && unlocked == true)
        {
            SceneManager.LoadScene(levelToLoad);
        }
        if (Input.GetKeyDown(KeyCode.E) && inTrigger == true && unlocked == false)
        {
            if (guessmenu.activeSelf==false)
            {
                
                guessmenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && guessmenu.activeSelf == true)
        {

            guessmenu.SetActive(false);
            Time.timeScale = 1.0f;
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
