using Unity.Mathematics;
using UnityEngine;

public class SeagullNoises : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] noises;

    [SerializeField]
    private Vector2 volumeRange;

    private float volume;

    [SerializeField]
    private Vector2 noiseTimeRange;

    private float waitTime;
    private float currentWaitTime;
    private int noiseIdx;


    // Idle Stuff
    private void ChooseNoise()
    {
        waitTime = math.lerp(noiseTimeRange.x, noiseTimeRange.y, UnityEngine.Random.Range(0f, 1f));
        noiseIdx = UnityEngine.Random.Range(0, noises.Length);
        volume = math.lerp(volumeRange.x, volumeRange.y, UnityEngine.Random.Range(0f, 1f));
        currentWaitTime = waitTime;
    }

    private void Start()
    {
        ChooseNoise();
    }

    private void Update()
    {
        currentWaitTime -= Time.deltaTime;
        if (currentWaitTime <= 0)
        {
            SFXManager.Instance.PlaySFXClip(noises[noiseIdx], transform, volume);
            ChooseNoise();
        }   
    }
}
