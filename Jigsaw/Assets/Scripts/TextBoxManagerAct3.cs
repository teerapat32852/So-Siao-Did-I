using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBoxManagerAct3 : MonoBehaviour
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
    private bool fromcutscene = false;

   
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
        if (enable)
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
            if(currentLine==6&&line6==false)
            {
                line6 = true;
                textBox.SetActive(false);
                StartCoroutine(Returnfromcutscenegab());
            }
          
           
           
            if (currentLine==29&&line29==false)
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
            if (currentLine == 39 && line39== false)
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
            if(currentLine==41&&line41==false)
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
                note.SetActive(true);


                StartCoroutine(WaitForKeyDown(KeyCode.Return));
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


        if(parentpic.activeSelf)
            parentpic.SetActive(false);
        if(box.activeSelf)
            box.SetActive(false);
        if(note.activeSelf)
            note.SetActive(false);
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
}
