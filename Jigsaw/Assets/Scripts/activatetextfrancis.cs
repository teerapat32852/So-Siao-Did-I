using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatetextfrancis : MonoBehaviour
{


    public TextAsset theText;
    public Animator anim;
    public int startLine;
    public int endLine;

    public TextBoxManagerAct2 theTextBox;

    public bool requireButtonPress;
    private bool waitForPress;
    public bool destroyWhenActivated;
    // Use this for initialization
    void Start()
    {
        
        theTextBox = FindObjectOfType<TextBoxManagerAct2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (theTextBox.isActive == true)
            return;
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
     
        if (other.name == "francis")
        {
            anim = other.gameObject.GetComponent<Animator>();
            anim.SetBool("franstop" ,true);
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
        if (other.name == "francis")
        {
            waitForPress = false;
        }
    }
}
