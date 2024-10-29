using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    private static ButtonClick instance;

    private void Awake()
    {

        // Set this instance as the AudioManager
        instance = this;

        // Make sure the AudioManager persists across scenes
        DontDestroyOnLoad(gameObject);
    }
}