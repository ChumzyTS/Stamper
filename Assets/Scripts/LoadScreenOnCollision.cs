using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenOnCollision : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
