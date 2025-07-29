using System;
using TMPro;
using UnityEngine;

public class FriendDialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    [SerializeField]
    private string[] Lines;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        DialogueBox.SetActive(true);
        DialogueBox.GetComponent<Dialogue>().StartDialogue(Lines);
    }

    
}
