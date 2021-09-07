using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCheck : MonoBehaviour
{
    public GameObject[] checkPoint;
    bool[] check;

    void Start()
    {
        check = new bool[checkPoint.Length];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Check Point")
        {
            for(int i = 0; i < checkPoint.Length; i++)
            {
                if(checkPoint[i].gameObject == other.gameObject)
                {
                    check[i] = true;
                }
            }
        }
    }
}
