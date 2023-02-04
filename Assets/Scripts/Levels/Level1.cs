using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    [SerializeField] private CharacterController kid;
    // Start is called before the first frame update
    void Start()
    {
        kid.BubbleDialog.Say($"Where am I?", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
