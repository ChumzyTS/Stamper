using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public static SFXManager Instance;

    [SerializeField]
    private AudioSource SFXObject;
    [SerializeField]
    private AudioSource backgroundAudio;
    [SerializeField]
    private AudioClip backgroundTrack;
    [SerializeField]
    private float masterMusicVolume;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        PlaySFXLoop(backgroundTrack);
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
    public void PlaySFXLoop(AudioClip audioClip)
    {
        double soundVol = optionsMenu.GetComponent<OptionsMenu>().soundVol;
        backgroundAudio.clip = audioClip;

        backgroundAudio.volume = masterMusicVolume * (float)soundVol;

        backgroundAudio.Play();

        backgroundAudio.loop = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume()
    {
        double musicVol = optionsMenu.GetComponent<OptionsMenu>().musicVol;
        backgroundAudio.volume = masterMusicVolume * (float)musicVol;
    }
}
