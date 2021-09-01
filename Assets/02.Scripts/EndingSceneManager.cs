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
        time.text = DataManager.nowPlayer.time;

        StartCoroutine(FireWork());

        //rankingRank = ranking.transform.Find("Rank");
    }

    private void FixedUpdate()
    {
        Regex.IsMatch(UserNameInput.text, "^[0-9a-zA-Z°¡-ÆR]*$");
        userInput.characterLimit = 8;

        if (UserNameInput.text.Length > 1 & UserNameInput.text.Length != 0)
        {
            enterBtn.interactable = true;
        }
        
    }

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
    IEnumerator FireWork()
    {
        iTween.MoveTo(images[0], iTween.Hash("x", -400, "easeType", "easeOutElastic", "delay", 0.5f));
        iTween.MoveTo(images[1], iTween.Hash("x", 400, "easeType", "easeOutElastic", "delay", 0.5f));

        yield return new WaitForSeconds(1f);

        iTween.MoveTo(images[2], iTween.Hash("x", -605, "easeType", "easeOutElastic", "delay", 0.4f));
        yield return new WaitForSeconds(0.1f);
        iTween.MoveTo(images[3], iTween.Hash("x", 605, "easeType", "easeOutElastic", "delay", 0.3f));
        iTween.MoveTo(images[4], iTween.Hash("x", -752, "easeType", "easeOutElastic", "delay", 0.4f));
        yield return new WaitForSeconds(0.1f);
        iTween.MoveTo(images[5], iTween.Hash("x", 752, "easeType", "easeOutElastic", "delay", 0.5f));
        iTween.MoveTo(images[6], iTween.Hash("x", -650, "easeType", "easeOutElastic", "delay", 0.3f));
        iTween.MoveTo(images[7], iTween.Hash("x", 650, "easeType", "easeOutElastic", "delay", 0.3f));
    }
}
