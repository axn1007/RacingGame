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

    void RandomGasCan()
    {
        int num = Random.Range(0, 3);
        for(int i = 0; i < gasCans.Length; i++)
        {
            if(num == i)
            {
                gasCans[i].gameObject.SetActive(true);
                print("³Ê ³ª¿Í");
            }
            else
            {
                gasCans[i].gameObject.SetActive(false);
            }
        }
    }
}
