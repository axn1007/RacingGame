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

    // 유저 정보
    public TextMeshProUGUI rankingRank;
    public TextMeshProUGUI rankingName;
    public TextMeshProUGUI rankingTime;
    
    // ScrollView - Content
    public Transform content;
    // 순위 정보
    public GameObject ranking;

    public GameObject optionImage;
    bool isOption = false;

    // 엔딩씬에서 다시 레이싱 버튼을 눌렀는지 확인을 위해서
    public static bool isEndRacingBtn = false;

    // 게임 종료 전 붙잡기 위한 UI
    public GameObject ExitImage;

    // 폭죽
    public GameObject[] images;

    private void Awake()
    {
        // Json으로 저장해두었던 주행 시간을 불러오기
        time.text = DataManager.nowPlayer.time;

        // 폭죽 코루틴 실행
        StartCoroutine(FireWork());

        //rankingRank = ranking.transform.Find("Rank");
    }

    // Input Field에 한글자 이상 입력시 버튼 활성화 및 숫자, 영소문자, 영대문자, 한글 입력 가능
    private void FixedUpdate()
    {
        Regex.IsMatch(UserNameInput.text, "^[0-9a-zA-Z가-힣]*$");
        userInput.characterLimit = 8;

        if (UserNameInput.text.Length > 1 & UserNameInput.text.Length != 0)
        {
            enterBtn.interactable = true;
        }
        
    }

    // Scroll View 창에 시간과 유저이름 띄우기
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

    public void OnClickRacing()
    {
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

    // 폭죽 터지는 듯한 효과
    IEnumerator FireWork()
    {
        // 자연스러운 움직임을 위해 itween 실행 도중 오브젝트 활성화
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
