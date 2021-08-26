using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    //public TextMeshProUGUI oilText;
    // ���� ���¹ٰ� 0�� �� ��������� �ǵ��ư��� �ϱ����ؼ�
    public GameObject kart;
    public Transform sPos;

    // Ÿ�̸�
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
        // ��ȣ�� ȣ��
        StartCoroutine(TrafficLight());
        // ���� ���¹� ȣ��
        StartCoroutine(OilState());
        // Ÿ�̸� ȣ��
        StartCoroutine(Timer());
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

    // ���� ���¹�
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

    // Ÿ�̸�
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
