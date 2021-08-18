using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    public GameObject run;
    public GameObject to;
    public GameObject you;

    public GameObject kart;
    public Transform pos;
    NavMeshAgent nav;

    public GameObject optionImage;
    bool isOption = false;

    void Start()
    {
        nav = kart.GetComponent<NavMeshAgent>();

        YouMove();
        ToMove();
        RunMove();
    }

    void Update()
    {
        nav.SetDestination(pos.position);

        //for(int i = 0; i < road.Length; i++)
        //{
        //    kart.transform.forward = -road[i].transform.forward;
        //}

        //float dist = Vector3.Distance(kart.transform.position, pos.position);
        //if(dist >= 0.1)
        //{
        //    nav.SetDestination(pos1.position);
        //    kart.transform.forward = pos1.transform.forward;
        //}
    }

    private void YouMove()
    {
        iTween.MoveTo(you, iTween.Hash("x", 949, "easeType", "easeOutElastic", "delay", 1.5f));
    }
    private void ToMove()
    {
        iTween.MoveTo(to, iTween.Hash("x", 949, "easeType", "easeOutBounce", "delay", 2f));
    }
    private void RunMove()
    {
        iTween.MoveTo(run, iTween.Hash("x", 949, "easeType", "easeOutBounce", "delay", 2.5f));
    }

    public void OnClcikOptionbtn()
    {
        if(!isOption)
        {
            optionImage.gameObject.SetActive(true);
            isOption = true;
        }
        else
        {
            optionImage.gameObject.SetActive(false);
            isOption = false;
        }
    }

    public void OnClickTutorialBtn()
    {
        SceneManager.LoadScene("Tutorial Scene");
    }

    public void OnClickGoBtn()
    {
        SceneManager.LoadScene("KartSelect Scene");
    }

    public void OnClickExitBtn()
    {
        Application.Quit();
    }
}
