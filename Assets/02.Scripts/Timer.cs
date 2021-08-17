using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float time;

    private float ms;
    private float ss;
    private float mm;


    private void FixedUpdate()
    {
        StartCoroutine(StopWatch());
    }

    IEnumerator StopWatch()
    {
        if (GameManager.instance.isGreen == true)
        {
            time += Time.deltaTime;
            ms = (int)((time - (int)time) * 100);
            ss = (int)(time % 60);
            mm = (int)(time / 60 % 60);

            text.text = string.Format("{0:00}:{1:00}:{2:00}", mm, ss, ms);

            yield return null;
        }
    }

    //public string getTime(float time)
    //{
    //    string t = TimeSpan.FromSeconds(time).ToString("mm\\:ss\\:ff");
    //    string[] tokens = t.Split(':');
    //    return tokens[0] + ":" + tokens[1] + ":" + tokens[2];
    //}
}
