using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    void Awake()
    {
        animator.SetTrigger("FadeIn");
    }
}
