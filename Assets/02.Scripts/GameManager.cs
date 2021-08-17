using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        StartCoroutine(TrafficLight());

        StartCoroutine(OilState());
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
        if (isGreen == true)
        {
            slider.value -= 0.02f * Time.deltaTime;

            yield return new WaitForSeconds(1.0f);
            print(slider.value);
        }
    }
}
