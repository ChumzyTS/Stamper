using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendDialogue : MonoBehaviour
{
    public GameObject DialogueBox;

    [Header("Dialogue Lines")]
    [SerializeField]
    private int[] conversationLengths;
    [SerializeField]
    private string[] conversations;
    
    private int location = 0;

    private int conv = 0;

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
        if (DialogueBox.activeSelf == false)
        {
            DialogueBox.SetActive(true);


            List<string> lLines = new List<string>();
            for (int i = location; i < location + conversationLengths[conv]; i++)
            {
                lLines.Add(conversations[i]);
            }
            string[] lines = lLines.ToArray();
            lLines.Clear();

            DialogueBox.GetComponent<Dialogue>().StartDialogue(lines);
            
            if (conversationLengths.Length > conv + 1)
            {
                location += conversationLengths[conv];
                conv++;   
            }

            
                
        }
        
    }

    
}
