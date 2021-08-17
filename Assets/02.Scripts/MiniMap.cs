using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private LineRenderer lr;
    private GameObject trackPath;

    public GameObject kart;
    // 미니맵 카메라
    public GameObject miniMapCam;
    // 미니맵에 표시되는 Player
    public GameObject player;

    void Start()
    {
        ShowMiniMap();
    }


    void Update()
    {
        // 카트의 실시간 위치를 나타내기 위한 카트
        miniMapCam.transform.position = new Vector3(kart.transform.position.x, miniMapCam.transform.position.y, kart.transform.position.z);
        // 미니맵에 표시되는 Player 위치
        player.transform.position = new Vector3(kart.transform.position.x, player.transform.position.y, kart.transform.position.z);
    }

    // 미니맵
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

        // 미니맵 처음과 끝을 이어주기 위해서
        lr.SetPosition(path, lr.GetPosition(0));

        // 미니맵 두께
        lr.startWidth = 14f;
        lr.endWidth = 14f;
    }
}
