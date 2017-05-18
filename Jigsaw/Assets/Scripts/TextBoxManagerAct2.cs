using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBoxManagerAct2 : MonoBehaviour
{
    public GameObject[] alanmood;
    public GameObject alan1;
    public GameObject alan2;
    public GameObject alan3;
    public GameObject alan4;
    public GameObject alan5;
    public int currentleft;
    //public int currentright;
    private string[] split;
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
    public bool incutscene = false;
    public string leveltoload;
    // Use this for initialization
    void Start()
    {

        alanmood = new GameObject[5];
        alanmood[0] = alan1;
        alanmood[1] = alan2;
        alanmood[2] = alan3;
        alanmood[3] = alan4;
        alanmood[4] = alan5;
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
        if (!incutscene)
            checkconditions();
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
                        if(incutscene==true)
                        {
                            StartCoroutine(movedialoguecutscene());
                        }
                        else
                        {
                           // checkconditions();
                       split=textLines[currentLine].Split(';');
                        Debug.Log(split[0]);
                        StartCoroutine(TextScroll(split[0]));
                            if (currentleft != int.Parse(split[1]))
                            {
                                currentleft = int.Parse(split[1]);
                                changeLeft();
                            }
                        }
                        //if(currentright!=int.Parse(split[2]))
                        //    {
                        //    currentright = int.Parse(split[2]);
                        //    changeRight();
                        //}
                        
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
        split = textLines[currentLine].Split(';');
        currentleft = int.Parse(split[1]);
        changeLeft();
        //currentright = int.Parse(split[2]);

        Debug.Log(split[0]);
        StartCoroutine(TextScroll(split[0]));

    }
    private IEnumerator shiftcamback()
    {
        currentleft = 0;
        changeLeft();
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
    private IEnumerator movedialoguecutscene()
    {

        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);

        checkconditions();
        split = textLines[currentLine].Split(';');
        Debug.Log(split[0]);
        StartCoroutine(TextScroll(split[0]));
        if (currentleft != int.Parse(split[1]))
        {
            currentleft = int.Parse(split[1]);
            changeLeft();
        }
        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);

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
    void changeLeft()
    {
        for (int i=0;i<5;i++)
        {
            alanmood[i].SetActive(false);
        }
        if(currentleft==1)
        {
            alanmood[0].SetActive(true);
        }
        else if (currentleft == 2)
        {
            alanmood[1].SetActive(true);
        }
        else if (currentleft == 3)
        {
            alanmood[2].SetActive(true);
        }
        else if (currentleft == 4)
        {
            alanmood[3].SetActive(true);
        }
        else if (currentleft == 5)
        {
            alanmood[4].SetActive(true);
        }
    }
    //void changeRight()
    //{
    //    if(currentright==1)
    //    {

    //    }
    //    else if(currentright==2)
    //    {

    //    }
    //    else if (currentright == 3)
    //    {

    //    }
    //    else if (currentright == 4)
    //    {

    //    }
    //    else if (currentright == 5)
    //    {

    //    }
  
    //}
    void checkconditions()
    {
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

        //if (currentLine == 16 && line16 == false)
        //{
        //    line16 = true;
        //    textBox.SetActive(false);

        //    //            flashback3.SetActive(true);
        //    StartCoroutine(WaitForFlash(KeyCode.Return));
        //}
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

            textBox.SetActive(false);
            StartCoroutine(Changetocutscenegab());
            line35 = true;
            incutscene = true;
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

        if (currentLine == 39 && line39 == false)
        {
            line39 = true;
            gab3.SetActive(false);
            gab4.SetActive(true);

        }
        if (currentLine == 41 && line41 == false)
        {
            gab4.SetActive(false);
            gab5.SetActive(true);
            line41 = true;
            //  textBox.SetActive(false);
            // dropforitems.SetActive(true);
            //chapterend.SetActive(true);
            StartCoroutine(WaitForLoad());
            incutscene = false;

        }
    }
}
