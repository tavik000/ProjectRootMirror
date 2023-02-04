using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleDialog : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string showString;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        text.text = showString;
        spriteRenderer.transform.localScale = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Trigger(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Trigger(false);
        }
    }

    public void Trigger(bool isOn)
    {
        animator.SetBool("IsOn", isOn);
    }
    
    
}
