using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    
    public GameObject pauseMenu;
    public GameObject SFX;

    [Header("Buttons")]
    [SerializeField]
    public Button soundUp;
    public Button soundDown;
    public Button musicUp;
    public Button musicDown;
    public Slider volume;
    public double musicVol;
    public double soundVol;
    public float musicScale;
    public float soundScale;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionsActive()
    {
        soundUp.onClick.AddListener(() => sound(1));
        soundDown.onClick.AddListener(() => sound(-1));
        musicUp.onClick.AddListener(() => music(1));
        musicDown.onClick.AddListener(() => music(-1));
        volume.onValueChanged.AddListener(delegate { VolumeChange(); });
    }

    public void OptionsInactive()
    {

        soundUp.onClick.RemoveListener(() => sound(1));
        soundDown.onClick.RemoveListener(() => sound(-1));
        musicUp.onClick.RemoveListener(() => music(1));
        musicDown.onClick.RemoveListener(() => music(-1));
        volume.onValueChanged.RemoveListener(delegate { VolumeChange(); });

        gameObject.SetActive(false);
    }

    void sound(int soundChange)
    {
        if ((0.1 < soundScale && soundChange < 0) || (0.9 > soundScale && soundChange > 0))
        {
            soundScale = soundScale + (float)(0.1 * soundChange);
        }
        else
        {
            if (soundChange < 0)
            {
                soundScale = 0;
            }
            else if (soundChange > 0)
            {
                soundScale = 1;
            }
        }
        VolumeChange();
    }

    void music(int musicChange)
    {
        if ((0.1 < musicScale && musicChange < 0) || (.9 > musicScale && musicChange > 0))
        {
            musicScale = musicScale + (float)(0.1 * musicChange);
        }
        else
        {
            if (musicChange < 0)
            {
                musicScale = 0;
            }
            else if (musicChange > 0)
            {
                musicScale = 1;
            }
        }

        VolumeChange();
    }

    void VolumeChange()
    {
        musicVol = volume.value * musicScale;
        soundVol = volume.value * soundScale;
        SFX.GetComponent<SFXManager>().UpdateVolume();
    }

}
