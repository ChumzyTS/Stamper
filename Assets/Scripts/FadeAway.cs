using UnityEngine;

public class FadeAway : MonoBehaviour
{
    [SerializeField]
    private float fadeTime;
    private float currentFadeTime;

    [SerializeField]
    private float waitToFadeTime;

    private SpriteRenderer sr;

    void Start()
    {
        currentFadeTime = fadeTime + waitToFadeTime;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentFadeTime -= Time.deltaTime;
        if (currentFadeTime <= fadeTime)
        {
            if (currentFadeTime > 0)
            {
                sr.color = new Color(1, 1, 1, currentFadeTime / fadeTime);
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }
    }
}
