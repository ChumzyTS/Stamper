using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinaleController : MonoBehaviour
{
    public GameObject background;
    public Sprite doorClosed;
    public Sprite doorOpen;
    [SerializeField]
    private float waitTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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
        yield return new WaitForSeconds(waitTime);
        SetScene(doorOpen);
    }

    void SetScene(Sprite newSprite)
    {
        background.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

}
