using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private KeyCode pauseKey = KeyCode.Escape;
    public bool paused = false;
    public GameObject postcard;
    public GameObject optionsMenu;

    [Header("Buttons")]
    [SerializeField]
    public Button resume;
    public Button mainMenu;
    public Button options;
    public Button quit;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (postcard.activeSelf == false && paused == false)
            {
                Pause();
                
            } else
            {
                Unpause();
            }
        }
    }

    void Unpause()
    {
        Time.timeScale = 1;
        optionsMenu.GetComponent<OptionsMenu>().OptionsInactive();
        paused = false;
        options.onClick.RemoveListener(Unpause);
        mainMenu.onClick.RemoveListener(MainMenu);
        quit.onClick.RemoveListener(EndGame);
        options.onClick.RemoveListener(DisplayOptions);
        postcard.SetActive(false);
    }

    void Pause()
    {
        Time.timeScale = 0;
        postcard.SetActive(true);
        paused = true;
        resume.onClick.AddListener(Unpause);
        mainMenu.onClick.AddListener(MainMenu);
        quit.onClick.AddListener(EndGame);
        options.onClick.AddListener(DisplayOptions);
    }

    void MainMenu()
    {

    }

    void DisplayOptions ()
    {
        postcard.SetActive(false);
        optionsMenu.SetActive(true);
        optionsMenu.GetComponent<OptionsMenu>().OptionsActive();
    }

    void EndGame()
    {
        Application.Quit();
    }

}
