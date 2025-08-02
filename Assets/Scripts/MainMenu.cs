using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator boatAnimator;

    public void Play()
    {
        animator.SetTrigger("Play");
        boatAnimator.SetTrigger("Play");
    }

    public void Options()
    {
        animator.SetTrigger("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        animator.SetTrigger("MainMenu");
    }
}
