using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToQuit : MonoBehaviour
{
    public Button Quit;

    // Start is called before the first frame update
    void Start()
    {
        Quit.onClick.AddListener(OnClick) ;
    }

    // Update is called once per frame
    void OnClick()
    {
        Debug.Log("App Exit");
        Application.Quit();
    }
}
