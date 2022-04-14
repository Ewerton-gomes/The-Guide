using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider slider;

    public void LoadLevel(string level)
    {
        StartCoroutine(LoadLvl(level));
    }
    IEnumerator LoadLvl(string level)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
