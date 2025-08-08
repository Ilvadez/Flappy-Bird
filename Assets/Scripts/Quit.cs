using UnityEngine;
using UnityEditor;
public class Quit : MonoBehaviour
{
    public void QuitFromGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
