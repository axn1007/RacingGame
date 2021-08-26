using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public PlayerData playerData;

    public static PlayerData nowPlayer = new PlayerData();

    // 싱글톤
    public static DataManager instance = null;
    // 저장할 폴더 경로
    public string SAVE_FilePath;
    // 파일 이름
    public string SAVE_FileName = "/SaveFile.txt";

    void Awake()
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

        // 폴더 경로 캐싱
        SAVE_FilePath = Application.dataPath + "/Save/";

        // 해당 경로가 존재하지 않는다면
        if(!Directory.Exists(SAVE_FilePath))
        {
            Directory.CreateDirectory(SAVE_FilePath); // 폴더 생성(경로 생성)
        }
        print(SAVE_FilePath);
        //Save(nowPlayer);
    }


    // 현재 플레이어의 정보
    [ContextMenu("To Json Data")]
    public void Save(PlayerData data)
    {
        string jData = JsonUtility.ToJson(data); // 제이슨화 해주기
        File.WriteAllText(SAVE_FilePath + SAVE_FileName, jData);
        print(SAVE_FilePath + SAVE_FileName + "sdrsdr");
        Debug.Log("저장 완료");
        Debug.Log(jData);
    }

    // 정보 불러오기
    [ContextMenu("From Json Data")]
    public void Load()
    {
        if (File.Exists(SAVE_FilePath + SAVE_FileName))
        {
            string loadjData = File.ReadAllText(SAVE_FilePath + SAVE_FileName);
            nowPlayer = JsonUtility.FromJson<PlayerData>(loadjData);

            Debug.Log("로드 완료");
        }
        else
            Debug.Log("저장된 파일이 없습니다.");
    }
}

[System.Serializable] // 직렬화 해야 한 줄로 데이터들이 나열되어 저장 장치에 읽고 쓰기가 쉬워진다
public class PlayerData
{
    public int kartState = 0;
    public string UserName;
    public int rank;
    public string time;
}
