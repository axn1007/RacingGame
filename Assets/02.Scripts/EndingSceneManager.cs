using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class EndingSceneManager : MonoBehaviour
{
    public TMP_InputField UserNameInput;

    public TextMeshProUGUI rank;
    public TextMeshProUGUI name;
    public TextMeshProUGUI time;
    public GameObject ranking;

    private void Awake()
    {
        time.text = DataManager.nowPlayer.time;
    }

    public void OnClickRanking()
    {
        DataManager.nowPlayer.UserNameArr = name.text;
        //ranking.transform.GetChild.name = DataManager.nowPlayer.UserNameArr;

        //name = Regex.Replace(name, @"[^0-9a-zA-Z°¡-ÆR]");

        for (int i = 0; 10 > DataManager.nowPlayer.rankArr.Length; i++)
        {
            UserNameInput.text = DataManager.nowPlayer.UserNameArr;
            time.text = DataManager.nowPlayer.rankArr[i];
        }
    }
}
