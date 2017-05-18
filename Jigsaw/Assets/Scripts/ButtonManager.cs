using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    private string[] levels = {"2nd","3rd","act2","act3","act4","act5" };
    public void NewGameBtn(string newGameLevel)
    {
        SaveLoad.saveLoad.Delete();
        SceneManager.LoadScene(newGameLevel);
    }
    public void LoadGame()
    {
        SaveLoad.saveLoad.Load();
        int i = SaveLoad.saveLoad.level;
        SceneManager.LoadScene(levels[i]);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
