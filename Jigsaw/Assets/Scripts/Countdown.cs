using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour
{
    float timeLeft = 50.0f;
    public GameObject francis;
    public GameObject caughttrigger;
    public Text text;

    void Start()
    {
 
    }

    void Update()
    {
        if(timeLeft>0)
            timeLeft -= Time.deltaTime;
        text.text = "Time Left:" + Mathf.Round(timeLeft);
        if (timeLeft <= 0)
        {
            francis.SetActive(true);
            caughttrigger.SetActive(true);
        }
    }
}