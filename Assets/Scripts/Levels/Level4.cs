using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{
    [SerializeField] private CharacterController kid;

    private void Start()
    {
        kid.BubbleDialog.SetString("How can I do this by myself?");
        
    }
}

