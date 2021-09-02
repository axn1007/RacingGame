using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialKey : MonoBehaviour
{
    // PracticeCanvas
    public GameObject[] Keys;

    void Awake()
    {
        StartCoroutine(KeyStart());
    }

    IEnumerator KeyStart()
    {
        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);

        Keys[0].SetActive(true);
        
        yield return new WaitForSeconds(2f);

        Keys[0].SetActive(false);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);
        
        Keys[1].SetActive(true);

        yield return new WaitForSeconds(2f);

        Keys[1].SetActive(false);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);

        Keys[2].SetActive(true);

        yield return new WaitForSeconds(2f);

        Keys[2].SetActive(false);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);

        Keys[3].SetActive(true);

        yield return new WaitForSeconds(3f);

        Keys[3].SetActive(false);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);

        Keys[4].SetActive(true);

        yield return new WaitForSeconds(3f);

        Keys[4].SetActive(false);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);

        Keys[5].SetActive(true);

        yield return new WaitForSeconds(3f);

        Keys[5].SetActive(false);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoKey);

        Keys[6].SetActive(true);

        yield return new WaitForSeconds(3f);

        Keys[6].SetActive(false);

        yield return new WaitForSeconds(3f);

        Keys[7].SetActive(true);
        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoCrab);
    }


}
