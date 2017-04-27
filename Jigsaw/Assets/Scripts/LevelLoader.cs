using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour {
    public bool inTrigger;
    public string levelToLoad;
    public bool nobutton;
	// Use this for initialization
	void Start () {
        inTrigger = false;

	}
	
	// Update is called once per frame
	void Update () {
        if(nobutton)
        {
            if (inTrigger == true)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
	 else if(Input.GetKeyDown(KeyCode.W)&& inTrigger==true)
        {
            StartCoroutine(ChangeLvl());
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
    IEnumerator ChangeLvl()
    {
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime+.5f);
        SceneManager.LoadScene(levelToLoad);
    }
}