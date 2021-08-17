using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // �����
    public GameObject needle;
    private float startPos = 180f, endPos = -2f;
    private float desiredPos;

    public float kartSpeed;

    // ��ȣ��
    public GameObject[] trafficLight;

    // �ʷϺ��� ���� ��
    public bool isGreen = false;

    // ���� ���¹�
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

    // ����� ������Ʈ
    public void UpdateNeedle()
    {
        desiredPos = startPos - endPos;
        float temp = kartSpeed / 300;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPos - temp * desiredPos));
    }

    // ��ȣ��
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

    // ���� ���¹�
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
