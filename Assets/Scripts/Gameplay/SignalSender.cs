using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalSender : MonoBehaviour
{
    [SerializeField] private List<SignalReceiver> signalReceivers;

    public void SendSignal(bool isOn)
    {
        foreach (var receiver in signalReceivers)
        {
            receiver.TriggerSignal(isOn);
        }
    }
    
}
