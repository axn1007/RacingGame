using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartSelectManager : MonoBehaviour
{
    public GameObject[] showKart;
    public GameObject show;
    public GameObject car;

    public GameObject[] kartSelect;
    public GameObject[] kartCustom;

    public Material racerMat;
    public Material kartMat;
    //public Shader raceMat;
    //public Shader kartMat;

    private void Start()
    {
        //car.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Kart");
        //Color c = car.transform.GetComponent<MeshRenderer>().material.GetColor("Color_AF650A6F");
    }

    private void FixedUpdate()
    {
        if(showKart[0].activeSelf == true)
        {
            show.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
            //iTween.RotateTo(show, iTween.Hash("y", 200, "easeType", "easeOutElastic", "time", 1.5f));

            //for (int i = 0; i < 500; i++)
            //{
            //    show.transform.Rotate(0, i * speed * Time.deltaTime, 0);
            //}

            //for (int i = 0; i < 200; i++)
            //{
            //    showKart[0].transform.Rotate(0, i * Time.deltaTime, 0);
            //    if (i == 190)
            //    {
            //        i = 0;
            //    }
            //}

            //for(int i = 0; i <200; i++)
            //{
            //    showKart[0].transform.Rotate(0, 200, 0);
            //    if(showKart[0].transform.rotation.y == 190)
            //    {
            //        i = 0;
            //    }
            //}
        }

        if(showKart[1].activeSelf == true)
        {
            //show.transform.rotation = Quaternion.identity;
            //if (show.transform.rotation == Quaternion.Euler(0,0,0))
            //{
            show.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
            //}
            
        }

        if(showKart[2].activeSelf == true)
        {
            show.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
        }
    }

    public void OnClickCarBtn()
    {
        showKart[0].gameObject.SetActive(true);
        showKart[1].gameObject.SetActive(false);
        showKart[2].gameObject.SetActive(false);
        showKart[3].gameObject.SetActive(false);
    }

    public void OnClickShipBtn()
    {
        showKart[1].gameObject.SetActive(true);
        showKart[0].gameObject.SetActive(false);
        showKart[2].gameObject.SetActive(false);
        showKart[3].gameObject.SetActive(false);
    }

    public void OnClicKTrainBtn()
    {
        showKart[2].gameObject.SetActive(true);
        showKart[0].gameObject.SetActive(false);
        showKart[1].gameObject.SetActive(false);
        showKart[3].gameObject.SetActive(false);
    }

    public void OnClickKartSelect()
    {
        for(int i = 0; i < kartSelect.Length; i++)
        {
            kartSelect[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < kartCustom.Length; i++)
        {
            kartCustom[i].gameObject.SetActive(true);
        }
    }

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
        //racerMat.color = new Color(255, 238, 35);
        //kartMat.color = new Color(255, 238, 35);
        //print("노랑색으로 변했다!");
        //print(racerMat.color);

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
    }
}
