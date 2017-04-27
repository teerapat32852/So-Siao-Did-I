﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    public Texture2D fadetexture;
    public float fadespeed=0.8f;
    private int drawDepth= -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1; //-1=in 1=out

	// Use this for initialization
	void OnGUI ()
    {
        alpha += fadeDir * fadespeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), fadetexture);
    }
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadespeed);
    }
    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }
  
}
