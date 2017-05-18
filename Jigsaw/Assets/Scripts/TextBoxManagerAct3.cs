using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBoxManagerAct3 : MonoBehaviour
{
    public GameObject[] othermood;
    public GameObject[] alanmood;
    public GameObject alan1;
    public GameObject alan2;
    public GameObject alan3;
    public GameObject alan4;
    public GameObject alan5;
    public int currentleft;
    public int currentright;
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
    public bool enable = true;
    public GameObject boxtrigger;
    public GameObject dropforitems;
    public GameObject parentpic;
    public GameObject panto;
    public GameObject box;
    public GameObject note;
    public GameObject mom1;
    public GameObject mom2;
    public GameObject mom3;
    public GameObject weirdpic;
    public GameObject workdoor;
    public GameObject weirddoor1;
    public GameObject weirddoor2;
    public GameObject weirddoor3;
    public GameObject parentboxinscene;
    public GameObject noteinscene;
    public GameObject closelocket;
    public GameObject openlocket;
    public GameObject workpic;
    public GameObject completepic;
    public GameObject sneak1;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject key5;
    public GameObject gab4;
    public GameObject gab5;
    private bool line2;
    private bool line4;
    private bool line6;
    private bool line29;
    private bool line34;
    private bool line38;
    private bool line39;
    private bool line40;
    private bool line41;
    private bool line47;
    private bool line49;
    private bool line59;
    private bool line66;
    private bool line82;
    private bool line83;
    private bool line85;
    private bool line86;
    private bool line87;
    private bool line92;
    private bool line97;
    private bool line103;
    private bool line104;
    private bool line105;
    private bool line107;
    private bool line110;
    private bool fromcutscene = false;
    public bool incutscene = false;

   
    public string leveltoload;
    // Use this for initialization
    void Start()
    {
        othermood = new GameObject[5];
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
        if (enable)
        {
           

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
                        if (incutscene == true)
                        {
                            StartCoroutine(movedialoguecutscene());
                        }
                        else
                        {
                            // checkconditions();
                            split = textLines[currentLine].Split(';');
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
    private IEnumerator WaitFor(float sec)
    {
        enable = false;
        yield return new WaitForSeconds(sec);
        enable = true;

    }
    public float transitionDuration = 2.5f;
    
    IEnumerator Transition()
    {
        enable = false;
        float t = 0.0f;
        Vector3 startingPos = camcon.transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);


          camcon.transform.position = Vector3.Lerp(startingPos, panto.transform.position, t);
        }
        WaitFor(1);
        t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);


            camcon.transform.position = Vector3.Lerp(panto.transform.position,startingPos , t);
            
        }
        enable = true;
        yield return 0;


    }
    IEnumerator Changetocutscenegab()
    {
        enable = false;
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        textBox.SetActive(true);
        gab4.SetActive(true);
        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
        enable = true;

    }
    IEnumerator Returnfromcutscenegab()
    {
        enable = false;
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        gab5.SetActive(false);
        textBox.SetActive(true);
        
        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
        enable = true;

    }
    IEnumerator Changetocutscenemom()
    {
        enable = false;
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
       
        mom1.SetActive(true);
        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
        enable = true;

    }
    IEnumerator Returnfromcutscenemom()
    {
        enable = false;
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        mom3.SetActive(false);
        textBox.SetActive(true);

        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
        enable = true;

    }
    private IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        do
        {
            yield return null;
        } while (!Input.GetKeyDown(keyCode));

       // if (weirdpic.activeSelf)
            weirdpic.SetActive(false);
       // if(parentpic.activeSelf)
            parentpic.SetActive(false);
       // if(box.activeSelf)
            box.SetActive(false);
       // if(note.activeSelf)
            note.SetActive(false);
       // if (openlocket.activeSelf)
            openlocket.SetActive(false);
       // if (workpic.activeSelf)
            workpic.SetActive(false);
       // if (completepic.activeSelf)
            completepic.SetActive(false);
        dropforitems.SetActive(false);
        textBox.SetActive(true);

    }
    private IEnumerator WaitForFlash(KeyCode keyCode)
    {
        do
        {
            yield return null;
        } while (!Input.GetKeyDown(keyCode));



        mom1.SetActive(false);
       mom2.SetActive(false);
        mom3.SetActive(false);
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
    IEnumerator Changetocutscenesneak()
    {
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        sneak1.SetActive(true);
        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
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
    private IEnumerator returnfromsneak()
    {
        enable = false;
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        sneak1.SetActive(false);
        textBox.SetActive(true);

        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
        enable = true;

    }
    IEnumerator Changetocutscenekey()
    {
        enable = false;
        float fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        textBox.SetActive(true);
        key1.SetActive(true);
        
        fadeTime = GameObject.Find("fader").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
        enable = true;

    }
    IEnumerator Returnfromcutscenekey(KeyCode keyCode)
    {
        do
        {
            yield return null;
        } while (!Input.GetKeyDown(keyCode));

        DisableTextBox();
        yield return new WaitForSeconds(.8f);
        key5.SetActive(false);
        //flashback2.SetActive(false);
        //flashback3.SetActive(false);
        // dropforitems.SetActive(false);
        // gab5.SetActive(false);
        //  textBox.SetActive(true);


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
            textLines = new string[1];
            textLines = (textFile.text.Split('\n'));

        }
    }
    void changeLeft()
    {
        for (int i = 0; i < 5; i++)
        {
            alanmood[i].SetActive(false);
        }
        if (currentleft == 1)
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
    void changeRight()
    {
        if (currentright == 1)
        {

        }
        else if (currentright == 2)
        {

        }
        else if (currentright == 3)
        {

        }
        else if (currentright == 4)
        {

        }
        else if (currentright == 5)
        {

        }

    }
    void checkconditions()
    {
        if (currentLine == 2 && line2 == false)
        {
            textBox.SetActive(false);
            StartCoroutine(Changetocutscenegab());
            line2 = true;


        }
        if (currentLine == 4 && line4 == false)
        {
            line4 = true;
            gab4.SetActive(false);
            gab5.SetActive(true);
        }
        if (currentLine == 6 && line6 == false)
        {
            line6 = true;
            textBox.SetActive(false);
            StartCoroutine(Returnfromcutscenegab());
        }



        if (currentLine == 29 && line29 == false)
        {
            line29 = true;
            camcon.free = true;
            StartCoroutine(Transition());

        }
        else
        {
            camcon.free = false;
        }
        if (currentLine == 34 && line34 == false)
        {
            line34 = true;
            textBox.SetActive(false);
            dropforitems.SetActive(true);
            parentpic.SetActive(true);
            boxtrigger.SetActive(true);

            StartCoroutine(WaitForKeyDown(KeyCode.Return));
        }
        if (currentLine == 38 && line38 == false)
        {
            line38 = true;
            textBox.SetActive(false);

            StartCoroutine(Changetocutscenemom());

        }
        if (currentLine == 39 && line39 == false)
        {
            line39 = true;
            mom1.SetActive(false);

            mom2.SetActive(true);

        }
        if (currentLine == 40 && line40 == false)
        {
            line40 = true;
            mom2.SetActive(false);

            mom3.SetActive(true);
            //StartCoroutine(WaitForFlash(KeyCode.Return));
        }
        if (currentLine == 41 && line41 == false)
        {
            line41 = true;
            StartCoroutine(Returnfromcutscenemom());
        }
        if (currentLine == 47 && line47 == false)
        {
            line47 = true;
            textBox.SetActive(false);
            dropforitems.SetActive(true);
            box.SetActive(true);


            StartCoroutine(WaitForKeyDown(KeyCode.Return));
        }
        if (currentLine == 49 && line49 == false)
        {
            line49 = true;
            textBox.SetActive(false);
            dropforitems.SetActive(true);
            parentboxinscene.SetActive(true);
            noteinscene.SetActive(true);
            note.SetActive(true);
            weirddoor1.GetComponent<DoorWarp>().enabled = true;
            weirddoor2.GetComponent<DoorWarp>().enabled = true;
            weirddoor3.GetComponent<DoorWarp>().enabled = true;

            StartCoroutine(WaitForKeyDown(KeyCode.Return));
        }
        if (currentLine == 59 && line59 == false)
        {
            line59 = true;
            textBox.SetActive(false);
            dropforitems.SetActive(true);
            weirdpic.SetActive(true);

            StartCoroutine(WaitForKeyDown(KeyCode.Return));
        }
        if (currentLine == 66 && line66 == false)
        {
            line66 = true;
            workdoor.GetComponent<DoorWarp>().enabled = true;


        }
        if (currentLine == 82 && line82 == false)
        {
            line82 = true;
            textBox.SetActive(false);
            dropforitems.SetActive(true);
            closelocket.SetActive(true);





        }
        if (currentLine == 83 && line83 == false)
        {
            line83 = true;

            closelocket.SetActive(false);
            openlocket.SetActive(true);



            StartCoroutine(WaitForKeyDown(KeyCode.Return));
        }
    
        if (currentLine == 86 && line86 == false)
        {
            
            textBox.SetActive(false);
            StartCoroutine(Changetocutscenesneak());
            line86 = true;
           
        }
        if (currentLine == 87 && line87 == false)
        {
            line87 = true;
            textBox.SetActive(false);
            StartCoroutine(returnfromsneak());
            

        }

        if (currentLine == 92 && line92 == false)
        {
            line92 = true;
            textBox.SetActive(false);
            dropforitems.SetActive(true);
            workpic.SetActive(true);

            StartCoroutine(WaitForKeyDown(KeyCode.Return));
        }
        if (currentLine == 97 && line97 == false)
        {
            line97 = true;
            textBox.SetActive(false);
            dropforitems.SetActive(true);
            completepic.SetActive(true);

            StartCoroutine(WaitForKeyDown(KeyCode.Return));
        }
        if (currentLine == 103 && line103 == false)
        {
            line103 = true;
           // textBox.SetActive(false);
            StartCoroutine(Changetocutscenekey());
            incutscene = true;
        }
        if (currentLine == 104 && line104 == false)
        {
            line104 = true;
            key1.SetActive(false);
            key2.SetActive(true);
        }
        if (currentLine == 105 && line105 == false)
        {
            line105 = true;
            key2.SetActive(false);
            key3.SetActive(true);
        }
        if (currentLine == 107 && line107 == false)
        {
            line107 = true;
            key3.SetActive(false);
            key4.SetActive(true);
        }
        if (currentLine == 110 && line110 == false)
        {
            line110 = true;
            key4.SetActive(false);
            key5.SetActive(true);
            fromcutscene = true;
            incutscene = false;
            StartCoroutine(Returnfromcutscenekey(KeyCode.Return));
        }
    }
}
