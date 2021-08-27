using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextSceneManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject moveImage;
    private RectTransform rt;
    public GameObject moveImage2;
    private RectTransform rt2;
    private float speed = 300;

    public string typing = "LOADING.....";

    private void Awake()
    {
        rt = moveImage.GetComponent<RectTransform>();
        rt2 = moveImage2.GetComponent<RectTransform>();

        StartCoroutine(LoadingTyping());
    }

    private void FixedUpdate()
    {
        moveMove();
    }

    void moveMove()
    {
        rt.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        rt2.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

    IEnumerator LoadingTyping()
    {
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < typing.Length; i++)
        {
            text.text = typing.Substring(0, i);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
