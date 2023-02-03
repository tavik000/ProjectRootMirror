using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    public delegate void EventHandler(bool isOn);

    public EventHandler SignalEvent;

    public void TriggerSignal(bool isOn)
    {
        SignalEvent?.Invoke(isOn);
    }

    public void ResetReceiver()
    {
        SignalEvent = null;
    }
}
