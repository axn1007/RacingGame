using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartSelectManager : MonoBehaviour
{
    public GameObject[] showKart;

    private void FixedUpdate()
    {
        if(showKart[0].activeSelf == true)
        {
            for(int i = 0; i < 200 ; i ++)
            {
                showKart[0].transform.Rotate(0, i * Time.deltaTime, 0);
            }
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
}
