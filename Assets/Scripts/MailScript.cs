using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MailScript : MonoBehaviour
{
    
    public GameObject letter;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioClip deliverSfx;

    public void giveMail(Sprite mail)
    {

        letter.GetComponent<Image>().sprite = mail;
        StartCoroutine(deliverMail());
    }

    IEnumerator deliverMail()
    {
        letter.SetActive(true);
        animator.SetTrigger("Deliver");
        //SFXManager.Instance.PlaySFXClip(deliverSfx, transform, (float)SFXManager.Instance.optionsMenu.GetComponent<OptionsMenu>().soundVol);
        yield return new WaitForSeconds(1.9f);
        letter.SetActive(false);


    }

}

