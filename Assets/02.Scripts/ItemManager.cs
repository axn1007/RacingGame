using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject oil;
    public GameObject oil2;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("ÁÖÀ¯ÅëÀÌ¶û ºÎµúÇû´Ù!");

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
