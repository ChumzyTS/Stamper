using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinaleController : MonoBehaviour
{
    public GameObject background;
    public GameObject black;
    public Sprite doorClosed;
    public Sprite doorOpen;
    public GameObject dialogueBox;
    public Sprite mail;
    [SerializeField]
    private Sprite faceSprite;
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private string[] convo1;
    [SerializeField]
    private string[] convo2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartScene()
    {
        SetScene(doorClosed);
        StartCoroutine(FadeOut(black));
        yield return new WaitForSeconds(waitTime);
        dialogueBox.SetActive(true);
        dialogueBox.GetComponent<Dialogue>().StartDialogue(convo1, "Cecilia", true, -1, null, 7, false, null, -1, mail);
        while (dialogueBox.activeSelf == true) yield return null;
        SetScene(doorOpen);
        yield return new WaitForSeconds(2);
        dialogueBox.SetActive(true);
        dialogueBox.GetComponent<Dialogue>().StartDialogue(convo2, "Cecilia", false, -1, faceSprite, 7, true, null, 3, mail);
        while (dialogueBox.activeSelf == true) yield return null;
    }

    IEnumerator FadeOut(GameObject sprite)
    {
        SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            renderer.color = new Color(1, 1, 1, i);
            yield return null;
        }
        sprite.SetActive(false);
    }

    void SetScene(Sprite newSprite)
    {
        background.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

}
