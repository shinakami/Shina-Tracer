using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameInfoLoader : MonoBehaviour
{
    public StageRecord StageRecord;
    private string _path;

    void Awake()
    {
        try
        {
            _path = Path.Combine(Application.persistentDataPath, "StageRecord");
            StreamReader file = new StreamReader(_path);
        }
        catch (FileNotFoundException)
        {
           
            Debug.LogWarning("Record Storage status :" + System.IO.File.Exists(_path).ToString());
            CreateData(_path);

        }
        finally
        {
            DataLoad(_path);
        }
        

    }
    void CreateData(string path)
    {
        StreamWriter file = new StreamWriter(path);
        file.Write("");
        file.Close();
    }
    void DataLoad(string path)
    {
        StreamReader file = new StreamReader(path);
        string json = file.ReadToEnd();
        file.Close();
        JsonUtility.FromJsonOverwrite(json, StageRecord);
        Debug.Log("Data Stream Completed");
    }
}
