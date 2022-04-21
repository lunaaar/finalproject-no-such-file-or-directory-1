using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager _instance = null;

    public void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        foreach(Sound s in sounds)
        {
            s.setSource(gameObject.AddComponent<AudioSource>());
        }
    }
    
    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        
        if(sound == null)
        {
            return;
        }

        sound.getSource().Play();
    }

    public static AudioManager instance()
    {
        return _instance;
    }

}
