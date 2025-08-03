using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenOnCollision : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private Animator fader;
    [SerializeField]
    private float fadeOutTime;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (fader)
            {
                fader.SetTrigger("FadeOut");
                StartCoroutine(delay());
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSecondsRealtime(fadeOutTime);
        SceneManager.LoadScene(sceneName);
    }
}
