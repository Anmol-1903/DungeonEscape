using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Slider _progressBar;
    [SerializeField] GameObject _loadingScreen;
    IEnumerator LoadScene(string _sceneName)
    {
        _loadingScreen.SetActive(true);
        AsyncOperation _operation = SceneManager.LoadSceneAsync(_sceneName);
        while (!_operation.isDone)
        {
            _progressBar.value = _operation.progress * .9F;
            yield return null;
        }
    }
    public void StartButton(string _sceneName)
    {
        StartCoroutine(LoadScene(_sceneName));
    }
    public void MainMenuButton()
    {

    }
    public void QuitButton()
    {
        Application.Quit();
    }
}