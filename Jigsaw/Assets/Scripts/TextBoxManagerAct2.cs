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
    public GameObject timer;
    public GameObject gabtrigger;
    public GameObject gabbust;
    public GameObject chapterend;
    public GameObject gab1;
    public GameObject gab2;
    public GameObject gab3;
    public GameObject gab4;
    public GameObject gab5;
    private bool fromcutscene;
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
    private bool line38;
    private bool line39;
    private bool line41;
    private bool line40;
    private bool line36;
    private bool enable = true;
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
            textBox.SetActive(false);
            StartCoroutine(Changetocutscenedine());
            line14 = true;
            
            fromcutscene = true;
            StartCoroutine(WaitForFlash(KeyCode.Return));



        }
        if (currentLine == 15 && line15 == false)
        {
            
            
         
        }
        if (currentLine == 16 && line16 == false)
        {
            line16 = true;
            textBox.SetActive(false);

//            flashback3.SetActive(true);
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
        if (currentLine == 35&& line35 == false)
        {
            textBox.SetActive(false);
            StartCoroutine(Changetocutscenegab());
            line35 = true;
            countdown.SetActive(false);
            timer.SetActive(false);
            frantrigger.SetActive(false);
            

        }
        if (currentLine == 36 && line36 == false)
        {
            line36 = true;
            gab1.SetActive(false);
            gab2.SetActive(true);
            //textBox.SetActive(false);

        }
        if (currentLine == 37 && line37 == false)
        {
            line37 = true;
            gab2.SetActive(false);
            gab3.SetActive(true);

        }
        //if (currentLine == 39 && line39 == false)
        //{
        //    line39 = true;
           

        //}
        if (currentLine == 39 && line39 == false)
        {
            line39 = true;
            gab3.SetActive(false);
            gab4.SetActive(true);

        }
        if (currentLine == 41&& line41 == false)
        {
            gab4.SetActive(false);
            gab5.SetActive(true);
            line41 = true;
          //  textBox.SetActive(false);
           // dropforitems.SetActive(true);
            //chapterend.SetActive(true);
            StartCoroutine(WaitForLoad());

        }
        // theText.text = textLines[currentLine];
        if (enable == true)
        {
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

        DisableTextBox();
        yield return new WaitForSeconds(.8f);
        flashback1.SetActive(false);
        //flashback2.SetActive(false);
        //flashback3.SetActive(false);
       // dropforitems.SetActive(false);
       // gab5.SetActive(false);
        //  textBox.SetActive(true);
       

    }
    private IEnumerator WaitForLoad()
    {
        do
        {
            yield return null;
        } while (!Input.GetKeyDown(KeyCode.Return));
        player.canMove = false;

        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime+1);
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
    IEnumerator Changetocutscenedine()
    {
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        flashback1.SetActive(true);
        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);


    }
    IEnumerator Changetocutscenegab()
    {
        enable = false;
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        textBox.SetActive(true);
        gab1.SetActive(true);
        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
        enable = true;

    }
    private IEnumerator shiftcam()
    {

        player.canMove = false;
        camcon.shifting = true;
        yield return new WaitForSeconds(.6f);
        camcon.shifting = false;
        textBox.SetActive(true);
        isActive = true;

        camcon.isFollowing = false;
        StartCoroutine(TextScroll(textLines[currentLine]));

    }
    private IEnumerator shiftcamback()
    {
        isActive = false;
        textBox.SetActive(false);
        camcon.shiftingback = true;
        yield return new WaitForSeconds(.6f);
        camcon.shiftingback = false;

        camcon.isFollowing = true;
        player.canMove = true;
        textBox.SetActive(false);

    }
    private IEnumerator shiftcambackfromcutscene()
    {
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);


        isActive = false;
        textBox.SetActive(false);
        camcon.shiftingback = true;
        yield return new WaitForSeconds(.6f);
        camcon.shiftingback = false;

        camcon.isFollowing = true;

        textBox.SetActive(false);
        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
        player.canMove = true;
    }
    public void EnableTextBox()
    {
        player.indialogue = true;
        StartCoroutine(shiftcam());
        //textBox.SetActive(true);
        //isActive = true;
        //player.canMove = false;
        //camcon.isFollowing = false;
        //StartCoroutine(TextScroll(textLines[currentLine]));


    }
    public void DisableTextBox()
    {
        player.indialogue = false;
        if (fromcutscene == true)
        {
            StartCoroutine(shiftcambackfromcutscene());
        }
        else
        {
            StartCoroutine(shiftcamback());
        }
        //isActive = false;
        //camcon.isFollowing = true;
        //player.canMove = true;
        //textBox.SetActive(false);

    }
    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            fromcutscene = false;
            textLines = new string[1];
            textLines = (textFile.text.Split('\n'));

        }
    }
}
