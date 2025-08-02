using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    AudioClip BackgroundSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SFXManager.Instance.PlaySFXLoop(BackgroundSFX, transform, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
