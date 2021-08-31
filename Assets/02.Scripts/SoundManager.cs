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

    // BGM ����� �÷����ϴ� AudioSource
    public AudioSource bgmAudio;

    // BGM ����� �÷����ϴ� AudioSource
    public AudioSource eftAudio;

    // BGM ��������
    public AudioClip[] bgms;

    // EFT ��������
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
