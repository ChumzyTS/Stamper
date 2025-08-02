using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField]
    private float fadeOutTime;
    [SerializeField]
    private float stayTime;
    [SerializeField]
    private SpriteRenderer sr;

    private float currentFadeOutTime;

    void Awake()
    {
        currentFadeOutTime = fadeOutTime + stayTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentFadeOutTime -= Time.deltaTime;
        if (currentFadeOutTime <= fadeOutTime)
        {
            sr.color = new Color(1, 1, 1, currentFadeOutTime / fadeOutTime);
        }
        if (currentFadeOutTime <= 0)
        {
            DestroyImmediate(gameObject);
        }
    }
}
