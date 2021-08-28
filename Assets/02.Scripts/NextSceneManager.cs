using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NextSceneManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject moveImage;
    private RectTransform rt;
    public GameObject moveImage2;
    private RectTransform rt2;
    public GameObject moveImage3;
    private RectTransform rt3;
    public GameObject moveImage4;
    private RectTransform rt4;
    private float speed = 300;
    private float currTime;

    public string typing = "LOADING.....";

    private void Awake()
    {
        rt = moveImage.GetComponent<RectTransform>();
        rt2 = moveImage2.GetComponent<RectTransform>();
        rt3 = moveImage3.GetComponent<RectTransform>();
        rt4 = moveImage4.GetComponent<RectTransform>();

        StartCoroutine(LoadingTyping());
    }

    private void FixedUpdate()
    {
        moveMove();

        currTime += Time.deltaTime;
        if (currTime > 3)
        {
            SceneManager.LoadScene("Tutorial Scene");
        }

        if(KartSelectManager.isRacingBtn == true && currTime > 3)
        {
            SceneManager.LoadScene("Racing Scene");
        }
    }

    void moveMove()
    {
        rt.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        rt2.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        rt3.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        rt4.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

    IEnumerator LoadingTyping()
    {
        //yield return new WaitForSeconds(0f);

        for (int i = 0; i < typing.Length; i++)
        {
            text.text = typing.Substring(0, i);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
