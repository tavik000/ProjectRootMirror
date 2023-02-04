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
    [SerializeField] private AudioSource dialogSfx;

    private void Start()
    {
        dialogSfx = GetComponent<AudioSource>();
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
        if (isOn)
        {
            if (dialogSfx != null)
            {
                dialogSfx.PlayOneShot(dialogSfx.clip);
            }
        }

        animator.SetBool("IsOn", isOn);
    }


    public void Say(string content, float duration)
    {
        text.text = content;
        Trigger(true);
        StartCoroutine(DialogCoroutine(duration));
    }

    private IEnumerator DialogCoroutine(float duration)
    {
        float startTime = Time.time;
        while (Time.time < startTime + duration)
        {
            yield return null;
        }

        Trigger(false);
    }
}