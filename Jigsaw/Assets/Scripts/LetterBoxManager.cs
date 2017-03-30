﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LetterBoxManager : MonoBehaviour
{
    public CameraController camcon;
    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;
    public PlayerController player;
    public bool isActive;
    public bool stopPlayerMovement;
    private bool isTyping = false;
    private bool cancelTyping = false;
    public float typeSpeed;
    public GameObject letter;
    public GameObject photo;
    public GameObject dropforitems;
    public GameObject doortext;
    public GameObject chapterend;
    private bool line8;
    private bool line12;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        camcon = FindObjectOfType<CameraController>();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
        if (isActive)
        {
            EnableTextBox();
            camcon.isFollowing = false;
        }
        else
        {
            DisableTextBox();
            camcon.isFollowing = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }
        // theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {

                currentLine += 1;
                if (currentLine == 8&&line8==false)
                {
                    line8 = true;
                    textBox.SetActive(false);
                    dropforitems.SetActive(true);
                    letter.SetActive(true);
                    StartCoroutine(WaitForKeyDown(KeyCode.Return));
                }
                if (currentLine == 12 && line12== false)
                {
                    line12 = true;
                    textBox.SetActive(false);
                    dropforitems.SetActive(true);
                    photo.SetActive(true);
                    chapterend.SetActive(true);
                    doortext.SetActive(false);
                    StartCoroutine(WaitForKeyDown(KeyCode.Return));
                }
                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }


        }

    }
    private IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        do
        {
            yield return null;
        } while (!Input.GetKeyDown(keyCode));
       
            letter.SetActive(false);
       
            photo.SetActive(false);
        dropforitems.SetActive(false);
        textBox.SetActive(true);

    }
    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false; ;
    }
    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        player.canMove = false;
        camcon.isFollowing = false;
        StartCoroutine(TextScroll(textLines[currentLine]));


    }
    public void DisableTextBox()
    {
        isActive = false;
        camcon.isFollowing = true;
        player.canMove = true;
        textBox.SetActive(false);

    }
    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (textFile.text.Split('\n'));

        }
    }
}
