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

    // 주유 상태바
    public Slider slider;
    public TextMeshProUGUI oilText;
    public float oilNum = 50;

    // 주유 상태바가 0일 때 출발점으로 되돌아가게 하기위해서
    public Transform sPos;
    //public GameObject wheels;
    public GameObject player;

    // 타이머
    public TextMeshProUGUI text;
    public float time;

    private float ms;
    private float ss;
    private float mm;

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

    }


    private void FixedUpdate()
    {
        kartSpeed = KartMove.instance.KPH;

        UpdateNeedle();
        // 신호등 호출
        StartCoroutine(TrafficLight());
        // 주유 상태바 호출
        StartCoroutine(OilState());
        // 타이머 호출
        StartCoroutine(Timer());
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
            }
        }
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

            if(slider.value == 0 || oilNum == 0)
            {
                oilNum = 0;
                oilText.text = ((int)oilNum).ToString();

                KartMove.instance.maxTorque = 0;

                player.transform.position = sPos.position;
                player.transform.rotation = sPos.rotation;

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
        if (isGreen)
        {
            time += Time.deltaTime;
            ms = (int)((time - (int)time) * 100);
            ss = (int)(time % 60);
            mm = (int)(time / 60 % 60);

            text.text = string.Format("{0:00}:{1:00}:{2:00}", mm, ss, ms);

            yield return null;
        }
    }

    public void PauseBtn()
    {

    }

    public void OnClickExitBtn()
    {
        Application.Quit();
    }
}
