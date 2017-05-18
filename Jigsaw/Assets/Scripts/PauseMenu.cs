using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameObject pausemenu;
    public bool ispaused;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ispaused)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausemenu.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ispaused = !ispaused;
        }
    }
    public void MainMenu(string mainmenu)
    {
        SceneManager.LoadScene(mainmenu);
    }
    public void Resume()
    {
        ispaused = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
