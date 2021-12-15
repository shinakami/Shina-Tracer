using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonToMenu : MonoBehaviour
{
    public GameObject ButtonLayout;
    public Button tomenu;
    public Image background;
    public Text title;

    public SceneLoader SceneLoader;

    void Start()
    {
        tomenu.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        TransitionBacktoMenu();
    }
    void GotoMenuScene()
    {
        SceneLoader.LoadTheGame("MainMenu");
    }
    void TransitionBacktoMenu()
    {
        ButtonLayout.transform.DOLocalMoveX(2000, 1f);
        tomenu.transform.DOLocalMoveX(2000, 1f);
        title.transform.DOLocalMoveX(2000, 1f);
        background.DOFade(0, 1f);
        Invoke("GotoMenuScene", 1.1f);
    }

}
