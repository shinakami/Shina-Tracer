using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//���d���A������class
[Serializable]
public class LevelData
{
    public List<string> LevelName = new List<string>();

    public List<int> LevelDeathTime = new List<int>();

    public List<bool> LevelState = new List<bool>();
}


[CreateAssetMenu(fileName = "StageRecord", menuName ="GameRecorder/Add PlayingRecord")]
public class StageRecord : ScriptableObject
{

    
    //�s����Scrollview�����
    public List<string> StageRecordInfo = new List<string>();


    public LevelData LevelData;

    
    

}
