using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public enum BGM
    {
        BGM_Home,
        BGM_Tuto,
        BGM_KartSel,
        BGM_Racing,
        BGM_Ending
    }

    public enum EFT
    {
        EFT_HomeCar,
        EFT_TutoTyping,
        EFT_TutoKey,
        EFT_TutoCrab,
        EFT_Kart,
        EFT_Traffic,
        EFT_Traffic2,
        EFT_Engin,
        EFT_kartGo,
        EFT_Accel,
        EFT_Brake,
        EFT_Oil,
        EFT_Goal,
        EFT_End
    }

    // BGM 오디오 플레이하는 AudioSource
    public AudioSource bgmAudio;

    // BGM 오디오 플레이하는 AudioSource
    public AudioSource eftAudio;

    // Racing Scene에서 차량 주행 소리 플레이하는 AudioSource
    public AudioSource driveAudio;

    // BGM 음원파일
    public AudioClip[] bgms;

    // EFT 음원파일
    public AudioClip[] efts;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        //HomeSceneBgm();
    }

    //void HomeSceneBgm()
    //{
    //    audioSource.Play();
    //}

    public void PlayBGM(BGM type)
    {
        bgmAudio.PlayOneShot(bgms[(int)type]);
    }

    public void PlayEFT(EFT type)
    {
        eftAudio.PlayOneShot(efts[(int)type]);
    }
}
