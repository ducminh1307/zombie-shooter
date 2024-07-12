using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderManager : MonoBehaviour
{
    [SerializeField] private GameObject loadUI;
    [SerializeField] private Slider progressSlider;

    public static SceneLoaderManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(int sceneId)
    {
        Time.timeScale = 1.0f;
        StartCoroutine(LoadSceneCoroutine(sceneId));
    }

    public IEnumerator LoadSceneCoroutine(int sceneId)
    {
        progressSlider.value = 0;
        loadUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneId);
        asyncOperation.allowSceneActivation = false;
        float progress = 0f;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;

            if (progress >= .9f)
            {
                progressSlider.value = 1;
                loadUI.SetActive(false);
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
} 
