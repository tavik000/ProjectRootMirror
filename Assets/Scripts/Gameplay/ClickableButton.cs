using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableButton : MonoBehaviour
{
    [SerializeField] private SignalSender signalSender;
    [SerializeField] private Animator animator;
    [SerializeField] private bool cannotOff;

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

    private void Trigger(bool isOn)
    {
        if (cannotOff && !isOn)
        {
            return;
        }
        signalSender.SendSignal(isOn);
        animator.SetBool("IsOn", isOn);
    }
}