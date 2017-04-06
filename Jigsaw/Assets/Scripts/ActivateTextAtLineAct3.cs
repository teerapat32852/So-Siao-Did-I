using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLineAct3: MonoBehaviour
{

    public PlayerController player;
    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManagerAct3 theTextBox;

    public bool requireButtonPress;
    private bool waitForPress;
    public bool destroyWhenActivated;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        theTextBox = FindObjectOfType<TextBoxManagerAct3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.E))
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
            if (destroyWhenActivated == true)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
            if (destroyWhenActivated == true)
            {
                Destroy(gameObject);
            }

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            waitForPress = false;
        }
    }
    void OnDestroy()
    {
        player.transform.GetChild(1).gameObject.SetActive(false);
    }
}
