using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpTyping : MonoBehaviour
{
    
    //public TextMeshProUGUI text;
    //public GameObject helpImage;
    //public string typing  = "V키를 누르면 화면 전환이 가능합니다. ";
    //public string typing2 = " W,S,A,D,Q,E 키를 눌러서 자유롭게   주행하며    주행연습을 해보세요! ";

    // MethodCanvas
    public TextMeshProUGUI tx;
    public TextMeshProUGUI tx2;
    public TextMeshProUGUI tx3;
    public string ruleTyping  = "1. 트랙 한바퀴를 돌아 결승점까지 빨리 도착하여 랭킹에 나의 순위를 올립시다! ";
    public string ruleTyping2 = "2. 장애물과 부딪히면 다양한 패널티가 있으니 최대한 피해서 골인을 하십시오! ";
    public string ruleTyping3 = "3. Oil 상태바가 0이 되면 출발점으로 되돌아가니 주유통 아이템을 획득하여 사용하세요! ";

    void Start()
    {
        //TutorialKartMove.instance.enabled = false;

        SoundManager.instance.bgmAudio.volume = 0.3f;
        SoundManager.instance.PlayBGM(SoundManager.BGM.BGM_Tuto);

        StartCoroutine(RuleTyping());
    }

    /*
    private void FixedUpdate()
    {
        if (TutorialScene.isPractice == true || TutorialScene.isPractice2 == true)
        {
            TutorialKey();
            //StartCoroutine(KeyStart());
            TutorialScene.isPractice = false;
        }
    } */

    IEnumerator RuleTyping()
    {
        yield return new WaitForSeconds(1f);

        // 타이핑 소리
        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoTyping);

        for (int i = 0; i < ruleTyping.Length; i++)
        {
            tx.text = ruleTyping.Substring(0, i);

            yield return new WaitForSeconds(0.13f);
        }

        yield return new WaitForSeconds(0.5f);

        for (int y = 0; y < ruleTyping2.Length; y++)
        {
            tx2.text = ruleTyping2.Substring(0, y);

            yield return new WaitForSeconds(0.13f);
        }

        yield return new WaitForSeconds(0.5f);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoTyping);

        for (int u = 0; u < ruleTyping3.Length; u++)
        {
            tx3.text = ruleTyping3.Substring(0, u);

            yield return new WaitForSeconds(0.13f);
        }

        SoundManager.instance.eftAudio.Stop();
    }

    /*
    IEnumerator KeyStart()
    {
        Keys[0].SetActive(true);
        if(Input.GetKeyDown("w"))
        {
            print("");
            //yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[0].SetActive(false);
            Keys[1].SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            //yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[1].SetActive(false);
            Keys[2].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[2].SetActive(false);
            Keys[3].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[3].SetActive(false);
            Keys[4].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           // yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[4].SetActive(false);
            Keys[5].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
           // yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[5].SetActive(false);
            Keys[6].SetActive(true);
            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoCrab);
        }

        yield return null;

        //yield return new WaitForSeconds(0.5f);

        //helpImage.gameObject.SetActive(true);

        //// 타이핑 소리
        //SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoTyping);

        //for (int i = 0; i < typing.Length; i++)
        //{
        //    text.text = typing.Substring(0, i);

        //    yield return new WaitForSeconds(0.13f);
        //}
        //SoundManager.instance.eftAudio.Stop();

        //yield return new WaitForSeconds(1f);

        //SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoTyping);

        //for (int y = 0; y < typing2.Length; y++)
        //{
        //    text.text = typing2.Substring(0, y);

        //    yield return new WaitForSeconds(0.11f);
        //}

        //SoundManager.instance.eftAudio.Stop();
        //yield return new WaitForSeconds(1f);
        //helpImage.gameObject.SetActive(false);
    } */

    /*
    void TutorialKey()
    {
        Keys[0].SetActive(true);
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("W");
            //yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[0].SetActive(false);
            Keys[1].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[1].SetActive(false);
            Keys[2].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[2].SetActive(false);
            Keys[3].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[3].SetActive(false);
            Keys[4].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[4].SetActive(false);
            Keys[5].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            // yield return new WaitForSeconds(0.5f);

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
            Keys[5].SetActive(false);
            Keys[6].SetActive(true);
            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoCrab);
        }

    }*/
}
