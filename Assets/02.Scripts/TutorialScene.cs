using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{
    public GameObject methodCanvas;
    public GameObject practiceCanvas;

    public GameObject optionImage;
    public GameObject optionImage1;
    //public static bool isPractice = false;
    bool isOption = false;
    bool isOption1 = false;

    // Option 버튼
    public Image[] optionBtn;

    // 게임 종료 전 붙잡기 위한 UI
    public GameObject ExitImage;


    public void OnClickPracticeBtn()
    {
        SoundManager.instance.eftAudio.Stop();
        SceneManager.LoadScene("Tutorial Scene_2");
        //isPractice = true;
        //methodCanvas.gameObject.SetActive(false);
        //practiceCanvas.gameObject.SetActive(true);

    }

    public void OnClickGoBtn()
    {
        SoundManager.instance.bgmAudio.Stop();
        SoundManager.instance.eftAudio.Stop();
        SceneManager.LoadScene("KartSelect Scene");
    }
    
    public void OnClickHomeBtn()
    {
        SceneManager.LoadScene("Home Scene");
    }

    public void OnClcikOptionbtn()
    {
        if (!isOption)
        {
            optionImage.gameObject.SetActive(true);
            isOption = true;
        }
        else
        {
            optionImage.gameObject.SetActive(false);
            isOption = false;
        }
    }

    public void OnClickBGMOnBtn()
    {
        SoundManager.instance.bgmAudio.mute = false;

        optionBtn[0].color = Color.gray;
        optionBtn[1].color = Color.white;
    }
    public void OnClickBGMOffBtn()
    {
        SoundManager.instance.bgmAudio.mute = true;

        optionBtn[1].color = Color.gray;
        optionBtn[0].color = Color.white;
    }
    public void OnClickEFTOnBtn()
    {
        SoundManager.instance.eftAudio.mute = false;

        optionBtn[2].color = Color.gray;
        optionBtn[3].color = Color.white;
    }
    public void OnClickEFTOffBtn()
    {
        SoundManager.instance.eftAudio.mute = true;

        optionBtn[3].color = Color.gray;
        optionBtn[2].color = Color.white;
    }

    public void OnClcikOptionbtn1()
    {
        if (!isOption1)
        {
            optionImage1.gameObject.SetActive(true);
            isOption1 = true;
        }
        else
        {
            optionImage1.gameObject.SetActive(false);
            isOption1 = false;
        }
    }

    public void OnClickExitBtn()
    {
        Time.timeScale = 0;
        ExitImage.SetActive(true);
    }
    public void OnClickXBtn()
    {
        ExitImage.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickExitExitBtn()
    {
        Application.Quit();
    }
}
