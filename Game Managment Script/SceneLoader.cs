using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Animator Transition;
    public GameObject LoadingBar;
    public Slider Slider;
    public Text ProgressText;

    public float TransitionTime = 1.5f;
    public float Progress;
    public float Interval; 
    public float BarValue = 0;
    public void LoadTheGame(string Scene)
    {
        StartCoroutine(LoadScene(Scene));
    }

    IEnumerator LoadScene(string Scene)
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Single);
        if (Scene.Contains("Level"))
        {
            LoadingBar.SetActive(true);
        }
        Interval = Time.timeSinceLevelLoad;
        while (!operation.isDone)
        {
            double loadingPersentage = Math.Round((operation.progress / 0.9f) * 100, 1);
            Progress = Mathf.Clamp01(operation.progress / 0.9f ) * 100;

            DOTween.To(() => Slider.value, x => Slider.value = x, Progress, Interval);
            
            ProgressText.text = loadingPersentage + "%";

            yield return null;
            
        }
        
        
    }


}
