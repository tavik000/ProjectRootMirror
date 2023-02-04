using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    [SerializeField] private CharacterController kid;
    [SerializeField] private CharacterController adult;

    private void Start()
    {
        kid.BubbleDialog.SetString("I love you, mum.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            adult.BubbleDialog.Say("I miss you, mum.", 5);
        }
    }
}