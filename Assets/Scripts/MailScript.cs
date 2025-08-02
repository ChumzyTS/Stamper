using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MailScript : MonoBehaviour
{
    
    public GameObject letter;

    public void giveMail(Sprite mail)
    {
        
        letter.GetComponent<Image>().sprite = mail;
        StartCoroutine(deliverMail());
    }

    IEnumerator deliverMail()
    {
        letter.SetActive(true);
        yield return new WaitForSeconds(2);
        letter.SetActive(false);

        // Gem could maybe animate this to fly in from the left side, slow down in the middle, and then accelerate again leaving stage right?

    }

}

