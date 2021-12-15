using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int Seconds;

    public Text Text_time;
    public Text Text_tips;


    public GameObject Player;
    public GameObject ButtonToJump;

    private bool _isfirstStart = true;
    private bool _isPause;
    

    public GamePlayerBehavior GamePlayerBehavior;
    public Gamemanger Gamemanger;

    public void InitCountDouwn()
    {
        _isfirstStart = true;
        Seconds = 3;
        ButtonToJump.SetActive(false);
        StartCoroutine(Countdown());
    }

    public void GameTimeController()
    {
        if (!_isfirstStart)
        {
            //Pause&Resume Function Test1
            if (Input.GetKey(KeyCode.P))
            {
                GamePlayerBehavior.enabled = false;
                Text_time.enabled = true;
                Time.timeScale = 0;
                
                Text_time.text = "Pause";
                Text_tips.text = "Press R to resume";
                _isPause = true;
            }
            if (Input.GetKey(KeyCode.R))
            {
                if (_isPause)
                {
                    GamePlayerBehavior.enabled = true;
                    Text_time.text = "";
                    Time.timeScale = 1f;
                    
                    Text_tips.text = "Press P to pause";
                    _isPause = false;
                }
            }
        }
    }


    IEnumerator Countdown()
    {
        
        Text_time.text = Seconds.ToString("0");
        while (Seconds > 0)
        {
            yield return new WaitForSeconds(1);
            Seconds--;
            Text_time.text = Seconds.ToString("0");
        }
        Text_time.text = "GO!";
        yield return new WaitForSeconds(1);

        
        Player.SetActive(true);
        ButtonToJump.SetActive(true);
        Text_time.text = "";
        _isfirstStart = false;
    }
}
