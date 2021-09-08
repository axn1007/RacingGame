using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class EndingSceneManager : MonoBehaviour
{
    public TextMeshProUGUI UserNameInput;
    public TextMeshProUGUI time;
    public TMP_InputField userInput;
    public Button enterBtn;

    // ¿Ø¿˙ ¡§∫∏
    public TextMeshProUGUI rankingRank;
    public TextMeshProUGUI rankingName;
    public TextMeshProUGUI rankingTime;
    
    // ScrollView - Content
    public Transform content;
    // ¿˙¿Â«“ Content
    //public GameObject content2;
    //public GameObject[] ranks;
    // º¯¿ß ¡§∫∏
    public GameObject ranking;

    public GameObject optionImage;
    bool isOption = false;

    // ø£µ˘æ¿ø°º≠ ¥ŸΩ√ ∑π¿ÃΩÃ πˆ∆∞¿ª ¥≠∑∂¥¬¡ˆ »Æ¿Œ¿ª ¿ß«ÿº≠
    public static bool isEndRacingBtn = false;

    // Option πˆ∆∞
    public Image[] optionBtn;

    // ∞‘¿” ¡æ∑· ¿¸ ∫Ÿ¿‚±‚ ¿ß«— UI
    public GameObject ExitImage;

    // ∆¯¡◊
    public GameObject[] images;

    private void Awake()
    {
        if(DataManager.nowPlayer.ranking != null)
        {
            DataManager.nowPlayer.ranking[DataManager.nowPlayer.ranking.Length].transform.parent = content;
        }

        //content = DataManager.nowPlayer.ranking[DataManager.nowPlayer.ranking.Length];

        // Json¿∏∑Œ ¿˙¿Â«ÿµŒæ˙¥¯ ¡÷«‡ Ω√∞£¿ª ∫“∑Øø¿±‚
        time.text = DataManager.nowPlayer.time;

        // ∆¯¡◊ ƒ⁄∑Á∆æ Ω««‡
        StartCoroutine(FireWork());

        //rankingRank = ranking.transform.Find("Rank");
    }

    // Input Fieldø° «—±€¿⁄ ¿ÃªÛ ¿‘∑¬Ω√ πˆ∆∞ »∞º∫»≠ π◊ º˝¿⁄, øµº“πÆ¿⁄, øµ¥ÎπÆ¿⁄, «—±€ ¿‘∑¬ ∞°¥…
    private void FixedUpdate()
    {
        Regex.IsMatch(UserNameInput.text, "^[0-9a-zA-Z∞°-∆R]*$");
        userInput.characterLimit = 8;

        if (UserNameInput.text.Length > 1 & UserNameInput.text.Length != 0)
        {
            enterBtn.interactable = true;
        }
        
    }

    // Scroll View √¢ø° Ω√∞£∞˙ ¿Ø¿˙¿Ã∏ß ∂ÁøÏ±‚
    public void OnClickRanking()
    {
        
        DataManager.nowPlayer.UserNameArr = UserNameInput.text;
        rankingName.text = DataManager.nowPlayer.UserNameArr;
        rankingTime.text = time.text;

        GameObject R = Instantiate(ranking);
        R.transform.parent = content;
        R.gameObject.SetActive(true);

        if(DataManager.nowPlayer.ranking[DataManager.nowPlayer.ranking.Length] != null)
        {
            for (int i = 0; DataManager.nowPlayer.ranking[i]; i++)
            {
                DataManager.nowPlayer.ranking[i] = R.transform.gameObject;
                DataManager.instance.Save(DataManager.nowPlayer);
            }
        }
        else
        {
            DataManager.nowPlayer.ranking[0] = R.transform.gameObject;
            DataManager.instance.Save(DataManager.nowPlayer);
        }

        userInput.gameObject.SetActive(false);
        enterBtn.gameObject.SetActive(false);
    }

    public void SaveRank()
    {

    }

    public void OnClickRacing()
    {

        // ¥ŸΩ√ ∑π¿ÃΩÃ¿ª Ω√¿€«ﬂ¿ª ∂ß √º≈© ∆˜¿Œ∆Æ∏¶ √ ±‚»≠ Ω√ƒ—¡‡æﬂ «—¥Ÿ.
        //GameManager.isGoal1 = false;
        //GameManager.isGoal2 = false;
        for(int i = 0; i < KartMove.instance.check.Length; i++)
        {
            KartMove.instance.check[i] = false;
        }
        GameManager.isGoal1 = false;
        GameManager.isGoal2 = false;

        isEndRacingBtn = true;

        SceneManager.LoadScene("Next Scene");
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

    public void OnClickHomeBtn()
    {
        SceneManager.LoadScene("Home Scene");
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

    // ∆¯¡◊ ≈Õ¡ˆ¥¬ µÌ«— »ø∞˙
    IEnumerator FireWork()
    {
        // ¿⁄ø¨Ω∫∑ØøÓ øÚ¡˜¿”¿ª ¿ß«ÿ itween Ω««‡ µµ¡ﬂ ø¿∫Í¡ß∆Æ »∞º∫»≠
        iTween.MoveTo(images[0], iTween.Hash("x", 500, "easeType", "easeOutElastic", "delay", 0.5f));
        iTween.MoveTo(images[1], iTween.Hash("x", 1420, "easeType", "easeOutElastic", "delay", 0.5f));

        yield return new WaitForSeconds(0.1f);
        images[0].gameObject.SetActive(true);
        images[1].gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        images[2].gameObject.SetActive(true);
        iTween.MoveTo(images[2], iTween.Hash("x", 380, "easeType", "easeOutElastic", "delay", 0.4f));

        yield return new WaitForSeconds(0.1f);

        images[3].gameObject.SetActive(true);
        images[4].gameObject.SetActive(true);
        iTween.MoveTo(images[3], iTween.Hash("x", 1540, "easeType", "easeOutElastic", "delay", 0.3f));
        iTween.MoveTo(images[4], iTween.Hash("x", 250, "easeType", "easeOutElastic", "delay", 0.4f));

        yield return new WaitForSeconds(0.1f);

        images[5].gameObject.SetActive(true);
        images[6].gameObject.SetActive(true);
        images[7].gameObject.SetActive(true);
        iTween.MoveTo(images[5], iTween.Hash("x", 1670, "easeType", "easeOutElastic", "delay", 0.5f));
        iTween.MoveTo(images[6], iTween.Hash("x", 340, "easeType", "easeOutElastic", "delay", 0.3f));
        iTween.MoveTo(images[7], iTween.Hash("x", 1580, "easeType", "easeOutElastic", "delay", 0.3f));
    }
}
