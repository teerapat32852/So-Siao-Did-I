using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour {
    public int savinglevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   void OnLevelWasLoaded()
    {
        
        SaveLoad.saveLoad.level = savinglevel;
        SaveLoad.saveLoad.Save();
    }
}
