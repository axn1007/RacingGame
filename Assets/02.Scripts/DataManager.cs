using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public string filePath;

    private void Awake()
    {
        // 파일 경로 캐싱
        filePath = Application.persistentDataPath;
        print(filePath);
    }


    void Update()
    {
        
    }

    // 현재 플레이어의 정보
    public void Save(PlayerData data)
    {
        string jData = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, jData);
    }

    // 정보 불러오기
    public void Load()
    {
        string lData = File.ReadAllText(filePath);
      //nowPlayer = JsonUtility.FromJson<PlayerData>(lData);
    }
}
