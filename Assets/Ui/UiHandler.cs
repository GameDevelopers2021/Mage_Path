using UnityEditor;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    public void HandleToNextLevel()
    {
        //Application.Quit();
        EditorApplication.ExitPlaymode();
    }

    public void HandleExit()
    {
        //Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}
