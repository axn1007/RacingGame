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

    // ���� ���� �� ����� ���� UI
    public GameObject ExitImage;

    void Start()
    {
        nav = kart.GetComponent<NavMeshAgent>();

        StartCoroutine(HomeSound());

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

    IEnumerator HomeSound()
    {
        // Nav�ڵ��� ����Ʈ
        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_HomeCar);

        yield return new WaitForSeconds(1.2f);

        // ��Ʈ�� �����
        SoundManager.instance.PlayBGM(SoundManager.BGM.BGM_Home);
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

    public void OnClickGoBtn()
    {
        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Button);
        print(SoundManager.EFT.EFT_Button);

        SoundManager.instance.bgmAudio.Stop();
        SoundManager.instance.eftAudio.Stop();

        SceneManager.LoadScene("Next Scene");
        //SceneManager.LoadScene("Tutorial Scene");
        //SceneManager.LoadScene("KartSelect Scene");
    }

    public void OnClickExitBtn()
    {
        Time.timeScale = 0;
        ExitImage.SetActive(true);
    }
    public void OnClickXBtn()
    {
        ExitImage.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickExitExitBtn()
    {
        Application.Quit();
    }

    /* �񵿱� ����ȯ ����
    public void OnClickTutorialBtn()
    {
        StartCoroutine(LoadScene());

        //SceneManager.LoadScene("Tutorial Scene");
        //AsyncOperation op = SceneManager.LoadSceneAsync("Tutorial Scene");

        //op.allowSceneActivation = false;
    }

    IEnumerator LoadScene()
    {
        SceneManager.LoadScene("Next Scene");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Tutorial Scene");

        ////yield return null;

        //AsyncOperation op = SceneManager.LoadSceneAsync("Tutorial Scene");

        //op.allowSceneActivation = false;

        ////yield return new WaitForSeconds(0.5f);

        //SceneManager.LoadScene("Next Scene");

        ////yield return new WaitForSeconds(1f);

        //op.allowSceneActivation = true;
        //yield break;
    } */
}
