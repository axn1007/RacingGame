using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // 주유통 아이템
    public GameObject oil;
    public GameObject oil2;


    // 주유통 아이템 획득
    private void OnTriggerEnter(Collider other)
    {
        print("주유통이랑 부딪혔다!");

        if (other.CompareTag("GasCan"))
        {
            other.gameObject.SetActive(false);
            
            if (oil.activeSelf == false)
            {
                oil.gameObject.SetActive(true);
            }
            else if(oil.activeSelf == true)
            {
                oil2.gameObject.SetActive(true);
            }
        }
    }
}
