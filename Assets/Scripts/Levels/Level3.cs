using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    [SerializeField] private CharacterController adult;

    private void Start()
    {
        adult.BubbleDialog.SetString("Feel like someone is helping me...");
        
    }
}
