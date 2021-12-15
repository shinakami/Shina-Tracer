using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearGate : MonoBehaviour
{

    public Gamemanger Gamemanger;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player") //Gameover
        {
            Clear();
        }
    }
    void Clear()
    {
        Gamemanger.PlayerPostionCheck();
        Gamemanger.GamestateRecorder(true);
        Gamemanger.Transition.SetTrigger("Gameclear");
        Gamemanger.Gameover.text = "Clear";
        Gamemanger.Tips.text = "";
        Gamemanger.Player.SetActive(false);
        Gamemanger.IsGameOver = true;
        
        Debug.Log("Clear");
       
        GameObject particle = Instantiate(Gamemanger.Firework, Gamemanger.Player.transform.position, Gamemanger.Player.transform.rotation);
        Destroy(particle, 2.5f);
    }
}
