using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBoxManagerAct2 : MonoBehaviour
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
    public GameObject parentdoortext;
    public GameObject livingpic;
    public GameObject dropforitems;
    public GameObject flashtrigger;
    public GameObject frantrigger;
    public GameObject flashback1;
    public GameObject flashback2;
    public GameObject flashback3;
    public GameObject countdown;
    public GameObject gabtrigger;
    public GameObject gabbust;
    public GameObject chapterend;
    private bool line4;
    private bool line10;
    private bool line14;
    private bool line15;
    private bool line16;
    private bool line27;
    private bool line37;
    private bool line42;
    private bool line35;
    private bool line32;
    public string leveltoload;
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
        if (currentLine == 4 && line4 == false)
        {
            line4 = true;
            parentdoortext.SetActive(true);
        }
        if (currentLine == 10 && line10 == false)
        {
            line10 = true;
            textBox.SetActive(false);
            dropforitems.SetActive(true);
            livingpic.SetActive(true);
            flashtrigger.SetActive(true);
            frantrigger.SetActive(true);
            gabtrigger.SetActive(true);
            StartCoroutine(WaitForKeyDown(KeyCode.Return));
        }
        if (currentLine == 14 && line14 == false)
        {
            line14 = true;
            textBox.SetActive(false);
           
            flashback1.SetActive(true);
           
        }
        if (currentLine == 15 && line15 == false)
        {
            line15 = true;
            textBox.SetActive(false);

            flashback2.SetActive(true);
         
        }
        if (currentLine == 16 && line16 == false)
        {
            line16 = true;
            textBox.SetActive(false);

            flashback3.SetActive(true);
            StartCoroutine(WaitForFlash(KeyCode.Return));
        }
        if (currentLine == 27 && line27 == false)
        {
            line27 = true;
            countdown.SetActive(true);


        }
        if (currentLine == 32 && line32 == false)
        {
            line32 = true;
            SceneManager.LoadScene("gameoveract2");

        }
        if (currentLine == 35 && line35 == false)
        {
            line35 = true;
            countdown.SetActive(false);
            frantrigger.SetActive(false);


        }
        if (currentLine == 37 && line37 == false)
        {
            line37 = true;
            gabbust.SetActive(true);


        }
        if (currentLine == 42&& line42 == false)
        {
            gabbust.SetActive(false);
            line42 = true;
            textBox.SetActive(false);
            dropforitems.SetActive(true);
            chapterend.SetActive(true);
            StartCoroutine(WaitForLoad());

        }
        // theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
              

                currentLine += 1;
              
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

        

        livingpic.SetActive(false);
        dropforitems.SetActive(false);
        textBox.SetActive(true);

    }
    private IEnumerator WaitForFlash(KeyCode keyCode)
    {
        do
        {
            yield return null;
        } while (!Input.GetKeyDown(keyCode));



        flashback1.SetActive(false);
        flashback2.SetActive(false);
        flashback3.SetActive(false);
        dropforitems.SetActive(false);
      //  textBox.SetActive(true);

    }
    private IEnumerator WaitForLoad()
    {

        player.canMove = false;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(leveltoload);

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
