using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private LineRenderer lr;
    private GameObject trackPath;

    public GameObject player;
    // �̴ϸ� ī�޶�
    public GameObject miniMapCam;
    // �̴ϸʿ� ǥ�õǴ� Player
    public GameObject playerpos;

    void Start()
    {
        ShowMiniMap();
    }


    void Update()
    {
        // īƮ�� �ǽð� ��ġ�� ��Ÿ���� ���� īƮ
        miniMapCam.transform.position = new Vector3(player.transform.position.x, miniMapCam.transform.position.y, player.transform.position.z);
        // �̴ϸʿ� ǥ�õǴ� Player ��ġ
        playerpos.transform.position = new Vector3(player.transform.position.x, playerpos.transform.position.y, player.transform.position.z);
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
