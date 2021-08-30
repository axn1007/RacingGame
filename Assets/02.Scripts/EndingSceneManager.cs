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

    // 유저 정보
    public TextMeshProUGUI rankingRank;
    public TextMeshProUGUI rankingName;
    public TextMeshProUGUI rankingTime;
    
    // ScrollView - Content
    public Transform content;
    // 랭킹 정보
    public GameObject ranking;

    private void Awake()
    {
        time.text = DataManager.nowPlayer.time;

        //rankingRank = ranking.transform.Find("Rank");
    }

    private void FixedUpdate()
    {
        if (UserNameInput.text.Length > 1)
        {
            enterBtn.interactable = true;
        }
        else if (UserNameInput.text.Length > 10)
        {
            enterBtn.interactable = false;
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
}
