using UnityEngine;

public class CallSFX : MonoBehaviour
{
    [SerializeField]
    AudioClip backgroundMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SFXManager.Instance.PlaySFXClip(backgroundMusic, transform, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
