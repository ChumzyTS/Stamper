using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendDialogue : MonoBehaviour
{
    [Header("Name")]
    public string FName;
    [SerializeField]
    private bool hasHiddenName;
    [SerializeField]
    private int revealNameAt;
    private int revealNameIndex;

    [Header("Sprites")]
    [SerializeField]
    private Sprite faceSprite;
    [SerializeField]
    private Sprite stampedFaceSprite;
    [SerializeField]
    private Sprite windowSprite;
    [SerializeField]
    private Sprite stampedWindowSprite;
    public Sprite mail;

    [Header("Stamp Info (conv #)")]
    [SerializeField]
    private int friendID;
    [SerializeField]
    private int stampAt;
    [SerializeField]
    private int stamps;
    [SerializeField]
    private int maxStamps;

    [Header("Mail Info (line #)")]
    [SerializeField]
    private int mailAt;
    private int mailIndex;

    [Header("Dialogue Box")]
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
        gameObject.GetComponent<SpriteRenderer>().sprite = windowSprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public void RunDialogue()
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

            // Mailing
            if (mailAt > -1)
            {
                if (location + conversationLengths[conv] > mailAt)
                {
                    mailIndex = Math.Max(mailAt - location, -1);
                }
                else
                {
                    mailIndex = -1;
                }
            }

            // Stamping
            Sprite spriteFace = faceSprite;
            if (stamps > 0)
            {
                spriteFace = stampedFaceSprite;
            }

            bool stampAfter = false;

            if (stampAt > -1 && stamps < maxStamps)
            {
                if (stampAt == conv)
                {
                    stampAfter = true;
                    stamps++;
                }

            }

            // Sends Dialogue

            DialogueBox.GetComponent<Dialogue>().StartDialogue(lines, FName, hasHiddenName, revealNameIndex, spriteFace, friendID, stampAfter, gameObject, mailIndex);
            
            if (conversationLengths.Length > conv + 1)
            {
                location += conversationLengths[conv];
                conv++;   
            }

            
                
        }
        
    }

    public void StampSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = stampedWindowSprite;
    }
    
}
