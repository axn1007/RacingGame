using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class EndingSceneManager : MonoBehaviour
{
    public TextMeshProUGUI UserNameInput;
    public TextMeshProUGUI time;
    public TMP_InputField userInput;
    public Button enterBtn;

    // À¯Àú Á¤º¸
    public TextMeshProUGUI rankingRank;
    public TextMeshProUGUI rankingName;
    public TextMeshProUGUI rankingTime;
    
    // ScrollView - Content
    public Transform content;
    // ·©Å· Á¤º¸
    public GameObject ranking;

    // ÆøÁ×
    public GameObject[] images;

    private void Awake()
    {
        // JsonÀ¸·Î ÀúÀåÇØµÎ¾ú´ø ÁÖÇà ½Ã°£À» ºÒ·¯¿À±â
        time.text = DataManager.nowPlayer.time;

        // ÆøÁ× ÄÚ·çÆ¾ ½ÇÇà
        StartCoroutine(FireWork());

        //rankingRank = ranking.transform.Find("Rank");
    }

    // Input Field¿¡ ÇÑ±ÛÀÚ ÀÌ»ó ÀÔ·Â½Ã ¹öÆ° È°¼ºÈ­ ¹× ¼ýÀÚ, ¿µ¼Ò¹®ÀÚ, ¿µ´ë¹®ÀÚ, ÇÑ±Û ÀÔ·Â °¡´É
    private void FixedUpdate()
    {
        Regex.IsMatch(UserNameInput.text, "^[0-9a-zA-Z°¡-ÆR]*$");
        userInput.characterLimit = 8;

        if (UserNameInput.text.Length > 1 & UserNameInput.text.Length != 0)
        {
            enterBtn.interactable = true;
        }
        
    }

    // Scroll View Ã¢¿¡ ½Ã°£°ú À¯ÀúÀÌ¸§ ¶ç¿ì±â
    public void OnClickRanking()
    {
        
        DataManager.nowPlayer.UserNameArr = UserNameInput.text;
        rankingName.text = DataManager.nowPlayer.UserNameArr;
        rankingTime.text = time.text;

        GameObject R = Instantiate(ranking);
        R.transform.parent = content;
        R.gameObject.SetActive(true);

        userInput.gameObject.SetActive(false);
        enterBtn.gameObject.SetActive(false);
    }

    // ÆøÁ× ÅÍÁö´Â µíÇÑ È¿°ú
    IEnumerator FireWork()
    {
        // ÀÚ¿¬½º·¯¿î ¿òÁ÷ÀÓÀ» À§ÇØ itween ½ÇÇà µµÁß ¿ÀºêÁ§Æ® È°¼ºÈ­
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
