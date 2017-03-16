using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class box : MonoBehaviour
{

    public TextAsset theText;
    public GameObject popup;
    public int startLine;
    public int endLine;

    public BoxBoxManager theTextBox;


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
        theTextBox = FindObjectOfType<BoxBoxManager>();
    }

    // Update is called once per frame



}
