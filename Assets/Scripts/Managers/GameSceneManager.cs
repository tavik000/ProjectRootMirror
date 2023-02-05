using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : SingletonManager<GameSceneManager>
{
    [SerializeField] private int _toLoadNextLevelIndex;
    public void GoNextLevel()
    {
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(_toLoadNextLevelIndex);
    }
    
}