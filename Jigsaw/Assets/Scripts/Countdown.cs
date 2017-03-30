using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour
{
    float timeLeft = 30.0f;
    public GameObject francis;
    public GameObject caughttrigger;
    public Text text;

    void Start()
    {
 
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Time Left:" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            francis.SetActive(true);
            caughttrigger.SetActive(true);
        }
    }
}