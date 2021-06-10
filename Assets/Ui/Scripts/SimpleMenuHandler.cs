using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui.Scripts
{
    public class SimpleMenuHandler : MonoBehaviour
    {
        public void GoToNextScene(string sceneName)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(sceneName);
        }

        public void GoToNextScene(int sceneIndex)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(sceneIndex);
        }

        public void GoToNextScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        public void RestartScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ExitGame()
        {
            //EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
