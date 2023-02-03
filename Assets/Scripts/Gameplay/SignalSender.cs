using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalSender : MonoBehaviour
{
    [SerializeField] private SignalReceiver signalReceiver;

    public void SendSignal(bool isOn)
    {
        if (signalReceiver != null)
        {
            signalReceiver.TriggerSignal(isOn);
        }
    }
    
}
