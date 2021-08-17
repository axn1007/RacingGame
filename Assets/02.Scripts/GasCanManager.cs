using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCanManager : MonoBehaviour
{
    public GameObject[] gasCans;

    void Start()
    {
        RandomGasCan();
    }


    private void FixedUpdate()
    {
        //RandomGasCan();
    }

    // 랜덤으로 아이템 위치 배치
    void RandomGasCan()
    {
        int num = Random.Range(0, 3);
        for(int i = 0; i < gasCans.Length; i++)
        {
            if(num == i)
            {
                gasCans[i].gameObject.SetActive(true);
                print("너 나와");
            }
            else
            {
                gasCans[i].gameObject.SetActive(false);
            }
        }
    }
}
