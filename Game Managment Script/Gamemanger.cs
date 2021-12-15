
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class Gamemanger : MonoBehaviour
{
    
    public Text Tips;
    public Text DeathCount;
    public Text Gameover;
    
    
    public Transform FinalEntrance;
    public Transform Camera;

    public GameObject Player;
    public GameObject Firework;

    public Animator Transition;

    public LineScript LineScript;
    public StageRecord StageRecord;
    public Timer Timer;
    public CameraController CameraController;
    public SceneLoader SceneLoader;
    public GamePlayerBehavior GamePlayerBehavior;

    public Vector3 DeathPos, CameraDeathPos;

    

    private int _deathtime = 0;
    private int randomNumber;

    public bool IsGameOver = false;
    
    
    
    private float _distancefromEnd;
    private float _distanceCloseToEnd = 1000f;
   

  
    private string _path;

   
    void Awake()
    {
        _path = Path.Combine(Application.persistentDataPath, "StageRecord");
        LoadGameData(SceneManager.GetActiveScene().name, _path);
        DeathCount.text += _deathtime.ToString();
       
        Timer.InitCountDouwn();
         
    }



    void LateUpdate()
    {
        
        if (!IsGameOver)
        {

            Timer.GameTimeController();
            
        }
        

        _distancefromEnd = FinalEntrance.position.x - Player.transform.position.x;


    }

    


    public void RestartGame()
    {
        if (IsGameOver)
        {
            Debug.Log("RestartGame");
            CameraController.TransistionStart();
            Transition.SetTrigger("Restart");
            IsGameOver = false;
            
            Timer.InitCountDouwn();
            
           
        }
    }

    public void BacktoMenu()
    {
        if (IsGameOver)
        {
            Debug.Log("ExitGame");
            SceneLoader.LoadTheGame("MainMenu");
            DeathPos = Vector3.zero;
            CameraDeathPos = Vector3.zero;
        }
    }
   

    //存取Scrollview面板的遊戲紀錄格式
    public void GamestateRecorder(bool State)
    {
        Debug.Log("GamestateRecorder Activated");
       
        string recordData = "關卡紀錄: " + SceneManager.GetActiveScene().name + ", " + $"失敗累計次數: {_deathtime} 次" + ", 通關:" + State;
        StageRecord.StageRecordInfo.Add(recordData);
        SaveGameData(SceneManager.GetActiveScene().name, State, _path);
    }


  

    //Save&Load Data
    void LoadGameData(string level ,string path)
    {
        Debug.Log("LoadData: " + level);

        var levelData = StageRecord.LevelData;

        
        StreamReader file = new StreamReader(path);
        string json = file.ReadToEnd();
        JsonUtility.FromJsonOverwrite(json, StageRecord);
        file.Close();

        if (!levelData.LevelName.Contains(level))
        {
            levelData.LevelName.Add(level);
            levelData.LevelDeathTime.Add(_deathtime);
            levelData.LevelState.Add(false);
        }
        else if (levelData.LevelName.Contains(level))
        {
            int index = levelData.LevelName.IndexOf(level);
            _deathtime = levelData.LevelDeathTime[index];
        }
    }
    void SaveGameData(string level, bool State, string path)
    {
        Debug.Log("SaveData: " + level);

        var levelData = StageRecord.LevelData;

        int index = levelData.LevelName.IndexOf(level);
        levelData.LevelDeathTime[index] = _deathtime;
        if (!levelData.LevelState[index])
        {
            levelData.LevelState[index] = State;
        }

        string json = JsonUtility.ToJson(StageRecord);
        StreamWriter file = new StreamWriter(path);
        file.Write(json);
        file.Close();
    }

    public void PlayerPostionCheck()
    {
        DeathPos = Player.transform.position;
        CameraDeathPos = Camera.position;
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Player") 
        {
            PlayerPostionCheck();
            Transition.SetTrigger("Gameover");

            GamePlayerBehavior.Init();

            
            _deathtime++;
            DeathCount.text = $"FAIL X {_deathtime}";

            int selectRange = 5;
            var stateLine = LineScript.StateLine;

            if (_deathtime < stateLine.Length - selectRange)
            {
                randomNumber = Random.Range(_deathtime, _deathtime + selectRange);
            }
            else if (_deathtime > stateLine.Length - selectRange)
            {
                randomNumber = Random.Range(stateLine.Length - selectRange, stateLine.Length - 1);
            }
            Gameover.text = LineScript.StateLine[randomNumber];
            
          
            if (_distancefromEnd <= _distanceCloseToEnd)
            {
                Gameover.text = "跳這麼久還不是要下去";
            }


            Debug.Log("Gameover");
            IsGameOver = true;

            Player.SetActive(false);
          
            GameObject particle = Instantiate(Firework, Player.transform.position, Player.transform.rotation);
            Destroy(particle, 2.5f);
            GamestateRecorder(false);


        }
    }
}
