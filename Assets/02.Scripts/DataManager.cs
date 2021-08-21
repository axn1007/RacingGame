using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public string filePath;

    private void Awake()
    {
        // ���� ��� ĳ��
        filePath = Application.persistentDataPath;
        print(filePath);
    }


    void Update()
    {
        
    }

    // ���� �÷��̾��� ����
    public void Save(PlayerData data)
    {
        string jData = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, jData);
    }

    // ���� �ҷ�����
    public void Load()
    {
        string lData = File.ReadAllText(filePath);
      //nowPlayer = JsonUtility.FromJson<PlayerData>(lData);
    }
}
