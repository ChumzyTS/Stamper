using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    public void Start()
    {
        SceneManager.LoadScene(sceneName);
    }
}
