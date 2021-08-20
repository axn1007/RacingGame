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
        yield return new WaitForSeconds(2f);

        for(int i = 0; i < ruleTyping.Length; i++)
        {
            tx.text = ruleTyping.Substring(0, i);

            yield return new WaitForSeconds(0.13f);
        }

        yield return new WaitForSeconds(1f);

        for (int y = 0; y < ruleTyping2.Length; y++)
        {
            tx2.text = ruleTyping2.Substring(0, y);

            yield return new WaitForSeconds(0.13f);
        }

        yield return new WaitForSeconds(1f);

        for (int u = 0; u < ruleTyping3.Length; u++)
        {
            tx3.text = ruleTyping3.Substring(0, u);

            yield return new WaitForSeconds(0.13f);
        }
    }

    IEnumerator TypingStart()
    {
        yield return new WaitForSeconds(0.5f);

        helpImage.gameObject.SetActive(true);

        for(int i = 0; i < typing.Length; i++)
        {
            text.text = typing.Substring(0, i);

            yield return new WaitForSeconds(0.13f);
        }

        yield return new WaitForSeconds(1f);

        for(int y = 0; y < typing2.Length; y++)
        {
            text.text = typing2.Substring(0, y);

            yield return new WaitForSeconds(0.11f);
        }

        yield return new WaitForSeconds(1f);
        helpImage.gameObject.SetActive(false);
    }
}
