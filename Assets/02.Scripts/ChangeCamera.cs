using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    // 1��Ī ����
    public Transform oneView;
    // 3��Ī ����
    public Transform threeView;
    public float smooth = 5f;

    public bool cview;

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            cview = !cview;
        }

        ChangedCamera();
    }

    // ���� ��ȯ
    private void ChangedCamera()
    {
        if(cview)
        {
            transform.position = oneView.position;
            transform.rotation = oneView.rotation;
            transform.forward  = oneView.forward;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, threeView.position, Time.deltaTime * smooth);
            transform.LookAt(oneView);
        }
    }
}
