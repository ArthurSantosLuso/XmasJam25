using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;

    public void PlayGame()
    {
          Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
