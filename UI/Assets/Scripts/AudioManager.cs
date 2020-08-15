using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public AudioClip otherClip;
    AudioSource audioSource;
    LevelLoader l;
    string levelToLoad = "Menu";
    public SceneFader sceneFader;
                
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            sceneFader.FadeTo(levelToLoad);            
        }
        
    }

}