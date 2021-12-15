using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class ButtonCollectionToMenu : MonoBehaviour
{
    public Button ToMenu;
    public Canvas CollectionSpace;
    public Image BackGround;
    public Text Title;

    void Start()
    {
        ToMenu.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        TransitionBacktoMenu();
    }
    void GotoMenuScene()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    void TransitionBacktoMenu()
    {

        CollectionSpace.transform.DOLocalMoveX(3000, 1f);

        ToMenu.transform.DOLocalMoveX(2000, 1f);
        Title.transform.DOLocalMoveX(2000, 1f);
        BackGround.DOFade(0, 1f);
        Invoke("GotoMenuScene", 1.5f);
    }
}
