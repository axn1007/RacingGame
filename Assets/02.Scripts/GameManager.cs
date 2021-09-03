using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] kartLoad;

    // 계기판
    public GameObject needle;
    private float startPos = 180f, endPos = -2f;
    private float desiredPos;

    public float kartSpeed;

    // 신호등
    public GameObject[] trafficLight;

    // 초록불이 들어올 때
    public bool isGreen = false;
    public bool isGreen1 = false;

    // 주유 상태바
    public Slider slider;
    public TextMeshProUGUI oilText;
    public float oilNum = 50;

    // 주유 상태바가 0일 때 출발점으로 되돌아가게 하기위해서
    public Transform sPos;
    //public GameObject wheels;
    public GameObject player;
    public Image oilE;

    // 타이머
    public TextMeshProUGUI text;
    public float time;

    private float ms;
    private float ss;
    private float mm;

    // 정지버튼
    public bool isPause = false;

    // 골 확인
    public static bool isGoal1 = false;
    public static bool isGoal2 = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (DataManager.nowPlayer.kartState == 0)
        {
            kartLoad[0].gameObject.SetActive(true);
        }
        else if (DataManager.nowPlayer.kartState == 1)
        {
            kartLoad[1].gameObject.SetActive(true);
        }
        else
        {
            kartLoad[2].gameObject.SetActive(true);
        }

        // 신호등 호출
        StartCoroutine(TrafficLight());
        // 신호등 사운드
        StartCoroutine(TLSound());

    }


    private void FixedUpdate()
    {
        kartSpeed = KartMove.instance.KPH;

        UpdateNeedle();
        // 신호등 호출
        //StartCoroutine(TrafficLight());
        // 주유 상태바 호출
        StartCoroutine(OilState());
        // 타이머 호출
        StartCoroutine(Timer());
        // 타이머 정지
        Goal();
    }

    // 계기판 업데이트
    public void UpdateNeedle()
    {
        desiredPos = startPos - endPos;
        float temp = kartSpeed / 300;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPos - temp * desiredPos));
    }

    // 신호등
    IEnumerator TrafficLight()
    {
        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < trafficLight.Length; i++)
        {
            trafficLight[i].gameObject.SetActive(true);

            yield return new WaitForSeconds(1.0f);

            if(trafficLight[2].gameObject.activeSelf == true)
            {
                isGreen = true;
                isGreen1 = true;
            }

            yield return null;
        }
    }

    IEnumerator TLSound()
    {
        yield return new WaitForSeconds(1.0f);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Traffic);

        yield return new WaitForSeconds(1.0f);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Traffic);

        yield return new WaitForSeconds(1.0f);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Traffic2);

        yield return new WaitForSeconds(0.1f);

        SoundManager.instance.PlayBGM(SoundManager.BGM.BGM_Racing);
    }

    // 주유 상태바
    IEnumerator OilState()
    {
        if (isGreen)
        {
            slider.value -= 0.02f * Time.deltaTime;
            oilNum -= 1 * Time.deltaTime;
            oilText.text = ((int)oilNum).ToString();

            yield return new WaitForSeconds(1.0f);
            //print(slider.value);

            if (slider.value <= 10 || oilNum <= 10)
            {
                SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Oil);

                oilE.gameObject.SetActive(true);
            }
            if (slider.value == 0 || oilNum == 0)
            {
                oilNum = 0;
                oilText.text = ((int)oilNum).ToString();

                KartMove.instance.maxTorque = 0;

                player.transform.position = sPos.position;
                player.transform.rotation = sPos.rotation;

                SoundManager.instance.eftAudio.Stop();
                oilE.gameObject.SetActive(false);
                slider.value = 1;
                oilNum = 50;

                // 주유 상태바가 0일 때 출발점으로 되돌아가게 하기위해서
                //if (kartLoad[0].gameObject.acti
                //
                //eSelf == true)
                //{
                //    kartLoad[0].transform.position = sPos.position;
                //    kartLoad[0].transform.rotation = sPos.rotation;

                //    slider.value = 1;
                //}
                //else if(kartLoad[1].gameObject.activeSelf == true)
                //{
                //    kartLoad[1].transform.position = sPos.position;
                //    kartLoad[1].transform.rotation = sPos.rotation;

                //    slider.value = 1;
                //}
                //else
                //{
                //    kartLoad[2].transform.position = sPos.position;
                //    kartLoad[2].transform.rotation = sPos.rotation;

                //    slider.value = 1;
                //}
            }
        }
    }

    // 타이머
    IEnumerator Timer()
    {
        if (isGreen1)
        {
            time += Time.deltaTime;
            ms = (int)((time - (int)time) * 100);
            ss = (int)(time % 60);
            mm = (int)(time / 60 % 60);

            text.text = string.Format("{0:00}:{1:00}:{2:00}", mm, ss, ms);

            yield return null;
        }
    }

    void Goal()
    {
        if(isGoal1 == true && isGoal2 == true)
        {
            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Goal);

            print("골인");
            StopCoroutine(TrafficLight());
            StopCoroutine(Timer());
            isGreen1 = false;

            DataManager.nowPlayer.time = text.text;
            //DataManager.instance.Save(DataManager.nowPlayer);

            SceneManager.LoadScene("Ending Scene");
        }
    }

    public void OnClickPauseBtn()
    {
        if(!isPause)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        else
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }

    public void OnClickExitBtn()
    {
        Application.Quit();
    }
}
