using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private LineRenderer lr;
    private GameObject trackPath;

    public GameObject kart;
    // �̴ϸ� ī�޶�
    public GameObject miniMapCam;
    // �̴ϸʿ� ǥ�õǴ� Player
    public GameObject player;

    void Start()
    {
        ShowMiniMap();
    }


    void Update()
    {
        // īƮ�� �ǽð� ��ġ�� ��Ÿ���� ���� īƮ
        miniMapCam.transform.position = new Vector3(kart.transform.position.x, miniMapCam.transform.position.y, kart.transform.position.z);
        // �̴ϸʿ� ǥ�õǴ� Player ��ġ
        player.transform.position = new Vector3(kart.transform.position.x, player.transform.position.y, kart.transform.position.z);
    }

    // �̴ϸ�
    void ShowMiniMap()
    {
        lr = GetComponent<LineRenderer>();
        trackPath = this.gameObject;

        int path = trackPath.transform.childCount;
        lr.positionCount = path +1;

        for(int m = 0; m < path; m++)
        {
            lr.SetPosition(m, new Vector3(trackPath.transform.GetChild(m).transform.position.x, 5,
                                          trackPath.transform.GetChild(m).transform.position.z));
        }

        // �̴ϸ� ó���� ���� �̾��ֱ� ���ؼ�
        lr.SetPosition(path, lr.GetPosition(0));

        // �̴ϸ� �β�
        lr.startWidth = 14f;
        lr.endWidth = 14f;
    }
}
