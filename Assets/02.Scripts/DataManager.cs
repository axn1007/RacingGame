using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public PlayerData playerData;

    // 싱글톤
    public static DataManager instance = null;
    // 파일 경로
    public string filePath;
    // 현재 게임중인 플레이어 정보
    public static PlayerData nowPlayer = new PlayerData();

    private void Awake()
    {
        if( instance == null)
        {
            instance = this;
        }
        else if ( instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        // 파일 경로 캐싱
        filePath = Application.persistentDataPath + "/palyerdata.json";
        print(filePath);
    }

    // 현재 플레이어의 정보
    [ContextMenu("To Json Data")]
    public void Save(PlayerData data)
    {
        string jData = JsonUtility.ToJson(data);
        // 파일 경로 캐싱
        //string filePath = Path.Combine(Application.persistentDataPath + "/palyerData.json");
        //print(filePath);
        File.WriteAllText(filePath, jData);
    }

    // 정보 불러오기
    [ContextMenu("From Json Data")]
    public void Load()
    {
        string jData = File.ReadAllText(filePath);
        nowPlayer = JsonUtility.FromJson<PlayerData>(jData);
    }
}

[System.Serializable]
public class PlayerData
{
    public int kartState = 0;
    public string UserName;
    public int rank;
    public string time;
}
