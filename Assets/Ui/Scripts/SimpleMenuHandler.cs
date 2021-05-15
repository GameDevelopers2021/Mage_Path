using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui.Scripts
{
    public class SimpleMenuHandler : MonoBehaviour
    {
        public void GoToNextScene(string sceneName) => SceneManager.LoadScene(sceneName);
        
        public void GoToNextScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);

        public void GoToNextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        public void ExitGame()
        {
            EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
