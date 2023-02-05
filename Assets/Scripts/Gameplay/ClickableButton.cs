using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableButton : MonoBehaviour
{
    [SerializeField] private SignalSender signalSender;
    [SerializeField] private Animator animator;
    [SerializeField] private bool cannotOff;
    [SerializeField] private bool needKeepClicking = true;
    
    [SerializeField] private AudioSource clickSfx;
    
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
            if (needKeepClicking)
            {
                Trigger(false);
            }
        }
    }

    private void Trigger(bool isOn)
    {
        if (isOn)
        {
            if (clickSfx != null)
            {
                clickSfx.PlayOneShot(clickSfx.clip);
            }
        }
        if (cannotOff && !isOn)
        {
            return;
        }
        signalSender.SendSignal(isOn);
        animator.SetBool("IsOn", isOn);
    }
}