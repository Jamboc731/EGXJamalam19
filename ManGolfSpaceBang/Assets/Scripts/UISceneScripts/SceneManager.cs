using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsyncromously(sceneIndex));
    }

    IEnumerator LoadAsyncromously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadScenesAsync(sceneIndex);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }
}
