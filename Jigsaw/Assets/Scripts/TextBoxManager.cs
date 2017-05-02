using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
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
    private bool fromcutscene = false;
    public float typeSpeed;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        camcon = FindObjectOfType<CameraController>();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if(endAtLine==0)
        {
            endAtLine = textLines.Length - 1;
        }
        if(isActive)
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
        if(!isActive)
        {
            return;
        }
        player.canMove = false;
       // theText.text = textLines[currentLine];
        if(Input.GetKeyDown(KeyCode.Return))
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
            else if(isTyping&&!cancelTyping)
            {
                cancelTyping = true;
            }
                
           
        }
       
    }
    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text+= lineOfText[letter];
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
            textLines = new string[1];
            textLines = (textFile.text.Split('\n'));

        }
    }
}
