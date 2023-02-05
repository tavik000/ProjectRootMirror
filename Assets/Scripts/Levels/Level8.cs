using System;
using System.Collections;
using UnityEngine;


public class Level8 : MonoBehaviour
{
    [SerializeField] private CharacterController kid;
    [SerializeField] private CharacterController adult;

    public void ShowEndDialog()
    {
        StartCoroutine(DialogCoroutine());
    }

    private IEnumerator DialogCoroutine()
    {
        kid.BubbleDialog.Say("Who are you?", 4f);
        yield return new WaitForSeconds(2.5f);
        adult.BubbleDialog.Say("You will know soon", 4f);
    }
}
