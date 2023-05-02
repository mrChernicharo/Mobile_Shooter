using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    public static FadeCanvas instance;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;
    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStarted;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);


        StartCoroutine(FadeIn());
    }

    public void FaderLoadString(string levelName)
    {
        StartCoroutine(FadeOutString(levelName));
    }

    public void FaderLoadInt(int levelIdx)
    {
        StartCoroutine(FadeOutInt(levelIdx));
    }

    // lower canvasGroup alpha until it's fully transparent
    IEnumerator FadeIn()
    {
        loadingScreen.SetActive(false);
        fadeStarted = false;
        while (canvasGroup.alpha > 0)
        {
            if (fadeStarted) yield break; // in case it's called while fading

            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }

    // rise canvasGroup alpha until is full black
    IEnumerator FadeOutString(string levelName)
    {
        if (fadeStarted) yield break;

        fadeStarted = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }

        //SceneManager.LoadScene(levelName);
        Debug.Log($"FadeOutString {levelName}");
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;
        while (ao.isDone == false)
        {
            loadingBar.fillAmount = ao.progress / 0.9f;
            if(ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }

        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator FadeOutInt(int levelIdx)
    {
        if (fadeStarted) yield break;

        fadeStarted = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }

        //SceneManager.LoadScene(levelName);

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelIdx);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;
        while (ao.isDone == false)
        {
            loadingBar.fillAmount = ao.progress / 0.9f;
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }

        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(0.1f);
    }
}
