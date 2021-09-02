using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Application.Quit();
    }
}
