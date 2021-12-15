using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonToRestart : MonoBehaviour
{
    public Button BackToMenu;
    public Gamemanger Gamemanger;
    // Start is called before the first frame update
    void Start()
    {
        BackToMenu.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        TransitionRestart();
    }

   
    void TransitionRestart()
    {
        Gamemanger.RestartGame();
    }
}   
