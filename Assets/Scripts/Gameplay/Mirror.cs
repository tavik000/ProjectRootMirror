using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] private AudioSource _nextLevelSfx;
    [SerializeField] private CharacterController _adult;
    [SerializeField] private CharacterController _kid;
    [SerializeField] private TouchMirrorTimeline touchMirror;
    
    private float _playerCount;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerCount++;
            if (other.gameObject.name.Contains("Adult"))
            {
                _adult = other.gameObject.GetComponent<CharacterController>();
            }
            
            if (other.gameObject.name.Contains("Kid"))
            {
                _kid = other.gameObject.GetComponent<CharacterController>();
            }
            if (_playerCount >= 2)
            {
                if (_nextLevelSfx != null)
                {
                    _nextLevelSfx.PlayOneShot(_nextLevelSfx.clip);
                }

                PlayTimeline();
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerCount--;
        }
    }

    public void PlayTimeline()
    {
        touchMirror.PlayTimeline(_adult, _kid);
        // Only for level 8
        
        
        Invoke(nameof(GoNextLevel),5);
    }

    // [SerializeField] private Level8 _level8;
    private void GoNextLevel()
    {
        GameSceneManager.Instance.GoNextLevel();
        // _level8 = FindObjectOfType<Level8>();
        // _level8.ShowEndDialog();
    }
    
}
