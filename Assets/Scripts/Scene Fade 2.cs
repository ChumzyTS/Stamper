using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    public Sprite sprite;
    private SpriteRenderer renderer;
    private bool pressFlag = false;

    void Awake() 
    {
        // the image you want to fade, assign in inspector
        renderer = GetComponent<SpriteRenderer>();
    }   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FadeImage(0));
            gameObject.SetActive(false);
        }
    }

    IEnumerator FadeImage(int fadeSelect)
    {
        // fade from opaque to transparent
        if (fadeSelect == 0)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                renderer.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else if (fadeSelect != 0)
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                renderer.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
