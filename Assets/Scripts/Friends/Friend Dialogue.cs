using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendDialogue : MonoBehaviour
{
    public string FName;
    [SerializeField]
    private bool hasHiddenName;
    [SerializeField]
    private int revealNameAt;
    private int revealNameIndex;
    [SerializeField]
    private Sprite faceSprite;
    [SerializeField]
    private Sprite stampedFaceSprite;
    [SerializeField]
    private Sprite windowSprite;
    [SerializeField]
    private Sprite stampedWindowSprite;

    [SerializeField]
    private int friendID;
    [SerializeField]
    private int stampAt;
    [SerializeField]
    private int stamps;
    [SerializeField]
    private int maxStamps;


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

    /*
    public void StampSprites()
    {
        this.faceSprite.sprite = stampedFaceSprite;
        this.windowSprite.sprite = stampedWindowSprite;
        return;
    }
    */

    private void OnMouseDown()
    {
        if (DialogueBox.activeSelf == false && conversationLengths.Length != 0)
        {
            DialogueBox.SetActive(true);


            List<string> lLines = new List<string>();
            for (int i = location; i < location + conversationLengths[conv]; i++)
            {
                lLines.Add(conversations[i]);
            }
            string[] lines = lLines.ToArray();
            lLines.Clear();

            if (hasHiddenName)
            {
                if (location + conversationLengths[conv] > revealNameAt)
                {
                    revealNameIndex = Math.Max(revealNameAt - location, 0);
                }
                else
                {
                    revealNameIndex = -1;
                }
            } else
            {
                revealNameIndex = 0;
            }

            bool stampAfter = false;

            if (stampAt > -1 && stamps < maxStamps)
            {
                if (stampAt == conv)
                {
                    stampAfter = true;
                }

            }
            

            DialogueBox.GetComponent<Dialogue>().StartDialogue(lines, FName, hasHiddenName, revealNameIndex, faceSprite, friendID, stampAfter, gameObject);
            
            if (conversationLengths.Length > conv + 1)
            {
                location += conversationLengths[conv];
                conv++;   
            }

            
                
        }
        
    }

    
}
