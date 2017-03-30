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
    private bool line5;
    private bool line29;
    private bool line34;
    private bool line47;
    private bool line49;

   
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
            if (currentLine == 5 && line5 == false)
            {
                line5 = true;
                StartCoroutine(WaitFor(3f));
            }
            if(currentLine==29&&line29==false)
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
    //private IEnumerator WaitForFlash(KeyCode keyCode)
    //{
    //    do
    //    {
    //        yield return null;
    //    } while (!Input.GetKeyDown(keyCode));



    //    flashback1.SetActive(false);
    //    flashback2.SetActive(false);
    //    flashback3.SetActive(false);
    //    dropforitems.SetActive(false);
    //    //  textBox.SetActive(true);

    //}
    //private IEnumerator WaitForLoad()
    //{

    //    player.canMove = false;
    //    yield return new WaitForSeconds(1.5f);
    //    SceneManager.LoadScene(leveltoload);

    //}
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
