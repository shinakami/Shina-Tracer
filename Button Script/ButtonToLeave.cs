using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonToLeave : MonoBehaviour
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
        Gamemanger.BacktoMenu();
    }

}
