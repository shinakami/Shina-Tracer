using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonToLevel : MonoBehaviour
{
    public GameObject ButtonLayout;
    public Button ToMenu;
    public Button Boss;
    public Image BackGround;
    public Text Title;

    public SceneLoader SceneLoader;

    
    void Start()
    {
        Boss.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        
        TransitionBacktoMenu();
    }
    void GotoMenuScene()
    {
        SceneLoader.LoadTheGame(Boss.name);
       
    }
    void TransitionBacktoMenu()
    {
        ButtonLayout.transform.DOLocalMoveX(2000, 1.5f);
        ToMenu.transform.DOLocalMoveX(2000, 1.5f);
        Title.transform.DOLocalMoveX(2000, 1.5f);
        BackGround.DOFade(0, 1.5f);
        Invoke("GotoMenuScene", 2f);
    }
}
