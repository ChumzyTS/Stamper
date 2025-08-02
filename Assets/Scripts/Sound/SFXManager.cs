using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public static SFXManager Instance;

    [SerializeField]
    private AudioSource SFXObject;
    [SerializeField]
    private AudioSource BackgroundMusic;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);
        double soundVol = optionsMenu.GetComponent<OptionsMenu>().soundVol;
        audioSource.clip = audioClip;

        audioSource.volume = volume * (float)soundVol;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
    public void PlaySFXLoop(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);
        double soundVol = optionsMenu.GetComponent<OptionsMenu>().soundVol;
        audioSource.clip = audioClip;

        audioSource.volume = volume * (float)soundVol;

        audioSource.Play();

        audioSource.loop = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
