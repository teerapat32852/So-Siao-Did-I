using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dial3 : MonoBehaviour
{
    public int one = 0;
    private Text text;
    public Button butt;

    // Use this for initialization
    void Start()
    {
        text = butt.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        text.text = one.ToString();
    }
    public void iterate()
    {
        if (one < 9)
            one++;
        else if (one == 9)
            one = 0;
    }
}
