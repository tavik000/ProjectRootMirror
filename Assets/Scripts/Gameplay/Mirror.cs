using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] private AudioSource _nextLevelSfx;
    private float _playerCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerCount++;
            if (_playerCount >= 2)
            {
                if (_nextLevelSfx != null)
                {
                    _nextLevelSfx.PlayOneShot(_nextLevelSfx.clip);
                }

                GameSceneManager.GoNextLevel();
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
    
    
}
