using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonToCollection : MonoBehaviour
{
    // Start is called before the first frame update
    public Button ToCollection;
    public Image BackGround;
    public Text Title;
    public Canvas ButtonLayout;
    public SceneLoader SceneLoader;

    // Update is called once per frame
    void Start()
    {
        ToCollection.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        TransitionToRecord();
    }
    void GotoRecordScene()
    {
        SceneLoader.LoadTheGame("PicCollection");     
    }
    void TransitionToRecord()
    {

        ButtonLayout.transform.DOLocalMoveX(2000, 1f);
        Title.transform.DOLocalMoveX(2000, 1f);
        BackGround.DOFade(0, 1f);
        Invoke("GotoRecordScene", 1.5f);
    }
}
