using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    //public TextMeshProUGUI oilText;
    // 주유 상태바가 0일 때 출발점으로 되돌아가게 하기위해서
    public GameObject kart;
    public Transform sPos;

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

            yield return new WaitForSeconds(1.0f);
            //print(slider.value);

            if(slider.value == 0)
            {
                KartMove.instance.maxTorque = 0;
                //kart.GetComponent<Rigidbody>().velocity = Vector3.zero;
                //kart.gameObject.GetComponent<KartMove>().enabled = false;
                kart.transform.position = sPos.position;
                kart.transform.rotation = sPos.rotation;
                
                slider.value = 1;
                //KartMove.instance.wheels[].transform.eulerAngles = new Vector3(0, 0, 0);
                //yield return new WaitForSeconds(1.0f);
                //kart.gameObject.GetComponent<KartMove>().enabled = true;
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
}
