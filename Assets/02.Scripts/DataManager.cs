using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public PlayerData playerData;

    public static PlayerData nowPlayer = new PlayerData();

    // �̱���
    public static DataManager instance = null;
    // ������ ���� ���
    public string SAVE_FilePath;
    // ���� �̸�
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

        // ���� ��� ĳ��
        SAVE_FilePath = Application.dataPath + "/Save/";

        // �ش� ��ΰ� �������� �ʴ´ٸ�
        if(!Directory.Exists(SAVE_FilePath))
        {
            Directory.CreateDirectory(SAVE_FilePath); // ���� ����(��� ����)
        }
        print(SAVE_FilePath);
        //Save(nowPlayer);
    }


    // ���� �÷��̾��� ����
    [ContextMenu("To Json Data")]
    public void Save(PlayerData data)
    {
        string jData = JsonUtility.ToJson(data); // ���̽�ȭ ���ֱ�
        File.WriteAllText(SAVE_FilePath + SAVE_FileName, jData);
        print(SAVE_FilePath + SAVE_FileName + "sdrsdr");
        Debug.Log("���� �Ϸ�");
        Debug.Log(jData);
    }

    // ���� �ҷ�����
    [ContextMenu("From Json Data")]
    public void Load()
    {
        if (File.Exists(SAVE_FilePath + SAVE_FileName))
        {
            string loadjData = File.ReadAllText(SAVE_FilePath + SAVE_FileName);
            nowPlayer = JsonUtility.FromJson<PlayerData>(loadjData);

            Debug.Log("�ε� �Ϸ�");
        }
        else
            Debug.Log("����� ������ �����ϴ�.");
    }
}

[System.Serializable] // ����ȭ �ؾ� �� �ٷ� �����͵��� �����Ǿ� ���� ��ġ�� �а� ���Ⱑ ��������
public class PlayerData
{
    public int kartState = 0;
    public string UserNameArr;
    public string rankArr;
    public float userTime;
    public string time;
    public GameObject[] ranking;
}
