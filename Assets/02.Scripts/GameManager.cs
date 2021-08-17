using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            for(int i = 0; i < trafficLight.Length; i++)
            {
                trafficLight[i].gameObject.SetActive(true);

                yield return new WaitForSeconds(1.0f);

                if(trafficLight[2].gameObject.activeSelf == true)
                {
                    isGreen = true;
                }
            }
        }
    }

    // 주유 상태바
    IEnumerator OilState()
    {
        if (isGreen)
        {
            slider.value -= 0.02f * Time.deltaTime;

            yield return new WaitForSeconds(1.0f);
            //print(slider.value);
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
}
