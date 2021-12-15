using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToCleanData : MonoBehaviour
{
    public Button CleanData;
    public StageRecord StageRecord;

    private string _path;
    
    void Start()
    {
        _path = Path.Combine(Application.persistentDataPath, "StageRecord");
        CleanData.onClick.AddListener(Onclick);
    }
    void Onclick()
    {

        StreamWriter file = new StreamWriter(_path);
        file.Write("");
        file.Close();
        StageRecord.StageRecordInfo = new List<string>();
        StageRecord.LevelData = new LevelData();
        Debug.LogWarning("Data Destroyed!");

    }
   
    
}
