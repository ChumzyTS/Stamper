using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class House : MonoBehaviour
{
    public string FName;
    [SerializeField]
    private Sprite faceSprite;
    private bool pressed;

    public GameObject DialogueBox;

    [Header("Dialogue Lines")]
    
    [SerializeField]
    private string[] conversations;
    
    private int location = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Wait for a few seconds before "knock knock!"
        StartCoroutine(FadeAndWait(3));
    }

    IEnumerator<object> FadeAndWait(int seconds)
    {
        Color c = GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            GetComponent<Renderer>().material.color = c;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(seconds);
        yield return null;
    } 
}
