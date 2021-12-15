using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonToPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public Button StartPlay;
    public Image BackGround;
    public Text Title;
    public Canvas ButtonLayout;

    public SceneLoader SceneLoader;
    void Start()
    {    
        StartPlay.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        TransitionToPlay();
    }
    void GotoScene()
    {
        SceneLoader.LoadTheGame("SelectLevel");
  
    }
    void TransitionToPlay()
    {
        ButtonLayout.transform.DOLocalMoveX(2000, 1.5f);
        Title.transform.DOLocalMoveX(2000, 1.5f);
        BackGround.DOFade(0, 1.5f);
        Invoke("GotoScene", 1.6f);
    }
}
