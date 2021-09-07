using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // ¡÷¿Ø≈Î æ∆¿Ã≈€
    public GameObject oil;
    public GameObject oil2;

    private void FixedUpdate()
    {
        UseItem();
    }

    // ¡÷¿Ø≈Î æ∆¿Ã≈€ »πµÊ
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GasCan"))
        {
            print("¡÷¿Ø≈Î¿Ã∂˚ ∫Œµ˙«˚¥Ÿ!");
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

    void UseItem()
    {
        if(oil.activeSelf == true && Input.GetKeyDown(KeyCode.R))
        {
            GameManager.instance.oilNum = 50;
            GameManager.instance.slider.value = 1;

            GameManager.instance.oilE.gameObject.SetActive(false);

            if(oil2.activeSelf == true)
            {
                oil2.gameObject.SetActive(false);
            }
            else if(oil2.activeSelf == false)
            {
                oil.gameObject.SetActive(false);
            }
        }
    }
}
