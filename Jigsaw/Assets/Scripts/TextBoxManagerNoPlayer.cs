using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManagerNoPlayer : MonoBehaviour
{
    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;
    public bool isActive;
    private bool isTyping = false;
    private bool cancelTyping = false;
    public float typeSpeed;
    public GameObject alanwfrancis;
    public GameObject alansleep;
    public GameObject alanbust;
    public GameObject francisbust;
    public GameObject alansleep2;
    public GameObject alansleep3;
    private bool enable=true;
    public AudioSource sound;
    public AudioClip gulp;
    public AudioClip walk;
    public AudioClip door;
    public string levelToLoad;
    private bool line3 = false;
    private bool line4 = false;
    private bool line8 = false;
    private bool line10 = false;
    private bool line12 = false;
    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
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

        }
        else
        {
            DisableTextBox();

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
        if (enable)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (!isTyping)
                {

                    currentLine += 1;
                    if (currentLine == 3&&line3==false)
                    {
                        line3 = true;
                        sound.PlayOneShot(gulp);
                        StartCoroutine(WaitFor(3));
                    }
                    if (currentLine == 4 && line4 == false)
                    {
                        line4 = true;
                        alanbust.SetActive(false);
                        francisbust.SetActive(false);
                        alanwfrancis.SetActive(true);
                        StartCoroutine(WaitFor(.5f));
                    }
                    if (currentLine == 8 && line8 == false)
                    {
                        line8 = true;
                        textBox.SetActive(false);
                        sound.PlayOneShot(walk);
                        alanwfrancis.SetActive(false);
                        alansleep.SetActive(true);
                        StartCoroutine(WaitForBox(5));
                        StartCoroutine(WaitSound(3));
                        
                    }
                    if (currentLine == 10 && line10 == false)
                    {
                        line10 = true;
                        textBox.SetActive(false);
                        alansleep.SetActive(false);
                        alansleep2.SetActive(true);
                        StartCoroutine(WaitForBox(5));
                        
                        
                    }
                    if (currentLine == 12 && line12 == false)
                    {
                        alansleep2.SetActive(false);
                        alansleep3.SetActive(true);
                        line12 = true;
                        StartCoroutine(WaitForLoad(5));

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

    }
    private IEnumerator WaitFor(float sec)
    {
        enable = false;
        yield return new WaitForSeconds(sec);
        enable = true;

    }
    private IEnumerator WaitForLoad(float sec)
    {
        enable = false;
        yield return new WaitForSeconds(sec);
        enable = true;
        SceneManager.LoadScene(levelToLoad);
    }
    private IEnumerator WaitSound(float sec)
    {
        enable = false;
        yield return new WaitForSeconds(sec);
        enable = true;
        sound.PlayOneShot(door);

    }
    private IEnumerator WaitForBox(float sec)
    {
        enable = false;
        yield return new WaitForSeconds(sec);
        enable = true;
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
        StartCoroutine(TextScroll(textLines[currentLine]));


    }
    public void DisableTextBox()
    {
        isActive = false;
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
