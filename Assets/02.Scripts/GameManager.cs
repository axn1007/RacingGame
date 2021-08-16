using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject needle;
    private float startPos = 180f, endPos = -2f;
    private float desiredPos;

    public float kartSpeed;

    void Awake()
    {

    }


    private void FixedUpdate()
    {
        kartSpeed = KartMove.instance.KPH;

        UpdateNeedle();
    }

    public void UpdateNeedle()
    {
        desiredPos = startPos - endPos;
        float temp = kartSpeed / 300;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPos - temp * desiredPos));
    }
}
