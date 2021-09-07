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

    // 카트선택 씬에서 레이싱 버튼을 눌렀는지 확인을 위해서 (false면 튜토리얼 씬으로, true면 레이싱 씬으로 이동)
    public static bool isRacingBtn = false;

    // Option 버튼
    public Image[] optionBtn;

    // 게임 종료 전 붙잡기 위한 UI
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
    // 카트 색 변경 보류..
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

    public void OnClickBGMOnBtn()
    {
        SoundManager.instance.bgmAudio.mute = false;

        optionBtn[0].color = Color.gray;
        optionBtn[1].color = Color.white;
    }
    public void OnClickBGMOffBtn()
    {
        SoundManager.instance.bgmAudio.mute = true;

        optionBtn[1].color = Color.gray;
        optionBtn[0].color = Color.white;
    }
    public void OnClickEFTOnBtn()
    {
        SoundManager.instance.eftAudio.mute = false;

        optionBtn[2].color = Color.gray;
        optionBtn[3].color = Color.white;
    }
    public void OnClickEFTOffBtn()
    {
        SoundManager.instance.eftAudio.mute = true;

        optionBtn[3].color = Color.gray;
        optionBtn[2].color = Color.white;
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
    // 쉐이더 그래프를 가져올 수 없어서 보류..
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
        print("노랑색으로 변해라!");
        racerMat.color = new Color(255, 238, 35);
        kartMat.color = new Color(255, 238, 35);
        print("노랑색으로 변했다!");
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
