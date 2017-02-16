using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuessController : MonoBehaviour {
    private int answer = 0;
    [SerializeField]
    private Text text;
    [SerializeField]
    private InputField input;
    void Awake()
    {

       // input = GameObject.Find("InputField").GetComponent<InputField>();
    }
	
	public void GetInput(string ans)
    {
        Debug.Log("You ENtered " + ans);
        Compare(ans);
        input.text = "";
    }
    void Compare(string ans)
    {
        if (ans == "0")
        {
            Debug.Log("right");
            text.text = "Correct,Door Unlocked";
            LockedDoor.unlocked = true;
        }
        else
        {
            Debug.Log("wrong");
            text.text = "Wrong";
        }
    }
}
