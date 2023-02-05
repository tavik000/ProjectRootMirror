using System;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _startBtn;

    private void Awake()
    {
        _startBtn.onClick.AddListener(OnClickStartButton);
    }

    private static void OnClickStartButton()
    {
        GameSceneManager.GoNextLevel();
    }
}
