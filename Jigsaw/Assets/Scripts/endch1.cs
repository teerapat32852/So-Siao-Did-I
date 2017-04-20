using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class endch1 : MonoBehaviour {

    public PlayerController player;

    public bool inTrigger;
    public GameObject endtext;
    public GameObject dropforitem;
    public bool nobutton;
    public string leveltoload;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        inTrigger = false;

    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.W) && inTrigger == true)
        {
            player.canMove = false;
            dropforitem.SetActive(true);
            endtext.SetActive(true);
            StartCoroutine(WaitForLoad());
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
    private IEnumerator WaitForLoad()
    {

        player.canMove = false;
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(leveltoload);

    }
}
