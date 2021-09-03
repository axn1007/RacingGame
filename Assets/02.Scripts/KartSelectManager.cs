using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum KartState
{
    KART_CAR,
    KART_SHIP,
    KART_TRAIN
}

public class KartSelectManager : MonoBehaviour
{
    public GameObject[] showKart;
    KartState state = new KartState();
    public GameObject show;
    public Image[] kartBtn;

    public GameObject[] kartSelect;
    public GameObject kartCustom;

    public Material racerMat;
    public Material kartMat;

    public GameObject optionImage;
    bool isOption = false;

    // īƮ���� ������ ���̽� ��ư�� �������� Ȯ���� ���ؼ� (false�� Ʃ�丮�� ������, true�� ���̽� ������ �̵�)
    public static bool isRacingBtn = false;

    // ���� ���� �� ����� ���� UI
    public GameObject ExitImage;

    void Start()
    {
        state = (KartState)DataManager.nowPlayer.kartState;

        SoundManager.instance.bgmAudio.volume = 0.2f;
        SoundManager.instance.PlayBGM(SoundManager.BGM.BGM_KartSel);

        //racerMat = showKart[0].transform.Find("Racer_Red").
        //car.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Kart");
        //Color c = car.transform.GetComponent<MeshRenderer>().material.GetColor("Color_AF650A6F");
    }

    private void FixedUpdate()
    {
        if(showKart[0].activeSelf == true)
        {
            show.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
        }

        if(showKart[1].activeSelf == true)
        {
            show.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
        }

        if(showKart[2].activeSelf == true)
        {
            show.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
        }
    }

    public void OnClickCarBtn()
    {
        state = KartState.KART_CAR;
        DataManager.nowPlayer.kartState = (int)state;
        DataManager.instance.Save(DataManager.nowPlayer);

        kartBtn[0].color = Color.gray;
        kartBtn[1].color = Color.white;
        kartBtn[2].color = Color.white;
        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Kart);

        showKart[0].gameObject.SetActive(true);
        showKart[1].gameObject.SetActive(false);
        showKart[2].gameObject.SetActive(false);
        showKart[3].gameObject.SetActive(false);
    }

    public void OnClickShipBtn()
    {
        state = KartState.KART_SHIP;
        DataManager.nowPlayer.kartState = (int)state;
        DataManager.instance.Save(DataManager.nowPlayer);

        kartBtn[1].color = Color.gray;
        kartBtn[0].color = Color.white;
        kartBtn[2].color = Color.white;
        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Kart);

        showKart[1].gameObject.SetActive(true);
        showKart[0].gameObject.SetActive(false);
        showKart[2].gameObject.SetActive(false);
        showKart[3].gameObject.SetActive(false);
    }

    public void OnClicKTrainBtn()
    {
        state = KartState.KART_TRAIN;
        DataManager.nowPlayer.kartState = (int)state;
        DataManager.instance.Save(DataManager.nowPlayer);

        kartBtn[2].color = Color.gray;
        kartBtn[0].color = Color.white;
        kartBtn[1].color = Color.white;
        SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Kart);

        showKart[2].gameObject.SetActive(true);
        showKart[0].gameObject.SetActive(false);
        showKart[1].gameObject.SetActive(false);
        showKart[3].gameObject.SetActive(false);
    }

    /*
    // īƮ �� ���� ����..
    public void OnClickKartSelect()
    {
        for(int i = 0; i < kartSelect.Length; i++)
        {
            kartSelect[i].gameObject.SetActive(false);
        }
        kartCustom.gameObject.SetActive(true);
    } */
    public void OnClickRacing()
    {
        SoundManager.instance.bgmAudio.Stop();

        isRacingBtn = true;
        SceneManager.LoadScene("Next Scene");
        //SceneManager.LoadScene("Racing Scene");
    }

    public void OnClcikOptionbtn()
    {
        if (!isOption)
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

    public void OnClickHomeBtn()
    {
        SceneManager.LoadScene("Home Scene");
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

    /*
    // ���̴� �׷����� ������ �� ��� ����..
    public void RedBtn()
    {
        racerMat.color = new Color(255, 0, 0);
        kartMat.color = new Color(255, 0, 0);
    }
    public void OrangeBtn()
    {
        racerMat.color = new Color(255, 116, 35);
        kartMat.color = new Color(255, 116, 35);
    }
    public void YellowBtn()
    {
        print("��������� ���ض�!");
        racerMat.color = new Color(255, 238, 35);
        kartMat.color = new Color(255, 238, 35);
        print("��������� ���ߴ�!");
        print(racerMat.color);

        //car.transform.GetComponent<MeshRenderer>().material.SetColor("Color_AF650A6F", new Color(255, 238, 35));
    }
    public void YGreentn()
    {
        racerMat.color = new Color(177, 255, 56);
        kartMat.color = new Color(177, 255, 56);
    }
    public void GreenBtn()
    {
        racerMat.color = new Color(17, 219, 25);
        kartMat.color = new Color(17, 219, 25);
    }
    public void MintBtn()
    {
        racerMat.color = new Color(20, 255, 246);
        kartMat.color = new Color(20, 255, 246);
    }
    public void SkyBtn()
    {
        racerMat.color = new Color(49, 204, 255);
        kartMat.color = new Color(49, 204, 255);
    }
    public void BlueBtn()
    {
        racerMat.color = new Color(33, 63, 245);
        kartMat.color = new Color(33, 63, 245);
    }
    public void PurpleBtn()
    {
        racerMat.color = new Color(191, 33, 245);
        kartMat.color = new Color(191, 33, 245);
    }
    public void PinkBtn()
    {
        racerMat.color = new Color(245, 33, 166);
        kartMat.color = new Color(245, 33, 166);
    } */
}
