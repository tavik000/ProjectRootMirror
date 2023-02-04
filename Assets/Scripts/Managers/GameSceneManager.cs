using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneManager
{
    public static void GoNextLevel()
    {
        LoadNextScene();
    }

    private static void LoadNextScene()
    {
        int count = EditorBuildSettings.scenes.Length;

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex + 1 < count)
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
        else
        {
            Debug.Log($"no level {currentIndex + 1}");
        }
    }
}