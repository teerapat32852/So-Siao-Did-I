using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingamemusic : MonoBehaviour {
    AudioSource aud;
    static bool AudioBegin = false;
    void Awake()
    {
        aud = GetComponent<AudioSource>();
        if (!AudioBegin)
        {
            aud.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update()
    {
     
    }
}
