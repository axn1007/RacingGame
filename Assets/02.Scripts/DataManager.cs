using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public PlayerData playerData;

    // �̱���
    public static DataManager instance = null;
    // ���� ���
    public string filePath;
    // ���� �������� �÷��̾� ����
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

        // ���� ��� ĳ��
        filePath = Application.persistentDataPath + "/palyerdata.json";
        print(filePath);
    }

    // ���� �÷��̾��� ����
    [ContextMenu("To Json Data")]
    public void Save(PlayerData data)
    {
        string jData = JsonUtility.ToJson(data);
        // ���� ��� ĳ��
        //string filePath = Path.Combine(Application.persistentDataPath + "/palyerData.json");
        //print(filePath);
        File.WriteAllText(filePath, jData);
    }

    // ���� �ҷ�����
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
