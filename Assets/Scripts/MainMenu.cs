using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator boatAnimator;
    [SerializeField]
    AudioClip selectSFX;

    public void Play()
    {
        SFXManager.Instance.PlaySFXClip(selectSFX, transform, 1f);
        animator.SetTrigger("Play");
        boatAnimator.SetTrigger("Play");
    }

    public void Options()
    {
        SFXManager.Instance.PlaySFXClip(selectSFX, transform, 1f);
        animator.SetTrigger("Options");
    }

    public void Quit()
    {
        SFXManager.Instance.PlaySFXClip(selectSFX, transform, 1f);
        Application.Quit();
    }

    public void Back()
    {
        SFXManager.Instance.PlaySFXClip(selectSFX, transform, 1f);
        animator.SetTrigger("MainMenu");
    }
}
