using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpTyping : MonoBehaviour
{
    // PracticeCanvas
    public TextMeshProUGUI text;
    public GameObject helpImage;
    public string typing  = "VŰ�� ������ ȭ�� ��ȯ�� �����մϴ�. ";
    public string typing2 = " W,S,A,D,Q,E Ű�� ������ �����Ӱ�   �����ϸ�    ���࿬���� �غ�����! ";

    // MethodCanvas
    public TextMeshProUGUI tx;
    public TextMeshProUGUI tx2;
    public TextMeshProUGUI tx3;
    public string ruleTyping  = "1. Ʈ�� �ѹ����� ���� ��������� ���� �����Ͽ� ��ŷ�� ���� ������ �ø��ô�! ";
    public string ruleTyping2 = "2. ��ֹ��� �ε����� �پ��� �г�Ƽ�� ������ �ִ��� ���ؼ� ������ �Ͻʽÿ�! ";
    public string ruleTyping3 = "3. Oil ���¹ٰ� 0�� �Ǹ� ��������� �ǵ��ư��� �������� ȹ���Ͽ� ����ϰų� �����ҿ� �湮�ϼ���! ";

    void Start()
    {
        SoundManager.instance.bgmAudio.volume = 0.3f;
        SoundManager.instance.PlayBGM(SoundManager.BGM.BGM_Tuto);

        StartCoroutine(RuleTyping());
    }

    private void FixedUpdate()
    {
        if (TutorialScene.isPractice == true)
        {
            TutorialScene.isPractice = false;
            StartCoroutine(TypingStart());
        }
    }

    IEnumerator RuleTyping()
    {
        yield return new WaitForSeconds(1f);

        // Ÿ���� �Ҹ�
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

    IEnumerator TypingStart()
    {
        yield return new WaitForSeconds(0.5f);

        helpImage.gameObject.SetActive(true);

        // Ÿ���� �Ҹ�
        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoTyping);

        for (int i = 0; i < typing.Length; i++)
        {
            text.text = typing.Substring(0, i);

            yield return new WaitForSeconds(0.13f);
        }
        SoundManager.instance.eftAudio.Stop();

        yield return new WaitForSeconds(1f);

        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_TutoTyping);

        for (int y = 0; y < typing2.Length; y++)
        {
            text.text = typing2.Substring(0, y);

            yield return new WaitForSeconds(0.11f);
        }

        SoundManager.instance.eftAudio.Stop();
        yield return new WaitForSeconds(1f);
        helpImage.gameObject.SetActive(false);
    }
}
