using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameWhenClick : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        // If running in the Unity Editor, stop the Play mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // If running in a built application, quit the game
            Application.Quit();
#endif
    }
}
