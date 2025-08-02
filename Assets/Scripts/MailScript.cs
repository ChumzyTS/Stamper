using UnityEngine;
using UnityEngine.UI;

public class MailScript : MonoBehaviour
{
    public Sprite mail;
    public GameObject letter;

    public void updateMail(Sprite mail)
    {
        letter.GetComponent<Image>().sprite = mail;
        letter.SetActive(true);
        return;
    }
}
