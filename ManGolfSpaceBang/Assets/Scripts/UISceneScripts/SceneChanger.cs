using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes{
    MainMenu
}

public class SceneChanger : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsyncromously(sceneIndex));
    }

    IEnumerator LoadAsyncromously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.PlayBGM();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
