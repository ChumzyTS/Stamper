using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class MailScript : MonoBehaviour
{
    public Sprite mail;

    private void updateMail(Sprite mail)
    {
        this.transform.FindChild("Letter").gameObject.GetComponent<SpriteRenderer>().sprite = mail;
        this.transform.FindChild("Letter").gameObject.SetActive(true);
        return;
    }
}
