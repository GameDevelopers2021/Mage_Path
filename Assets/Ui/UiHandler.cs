using UnityEditor;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    public void HandleToNextLevel()
    {
        EditorApplication.ExitPlaymode();
    }
}
