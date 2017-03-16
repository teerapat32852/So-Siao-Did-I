using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class letter : MonoBehaviour{

    public TextAsset theText;
    public GameObject popup;
    public int startLine;
    public int endLine;

    public LetterBoxManager theTextBox;

  
    public bool destroyWhenActivated;
    public void runtext()
    { 
        theTextBox.ReloadScript(theText);
        theTextBox.currentLine = startLine;
        theTextBox.endAtLine = endLine;
        theTextBox.EnableTextBox();
        if (destroyWhenActivated == true)
        {
            Destroy(gameObject);
        }
        popup.SetActive(false);

    }
   
    // Use this for initialization
    void Start()
    {
        theTextBox = FindObjectOfType<LetterBoxManager>();
    }

    // Update is called once per frame
   

  
}
