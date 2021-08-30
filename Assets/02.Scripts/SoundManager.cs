using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound
{
    BGM,
    EFFECT
}

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    //AudioClip audioClip;

    private void Awake()
    {
        HomeSceneBgm();
    }

    void HomeSceneBgm()
    {
        //audioSource.clip = audioClip;
        audioSource.Play();
    }
}
