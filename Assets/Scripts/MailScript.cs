using UnityEngine;

public class MailScript : MonoBehaviour
{
    public Sprite mail;
    public GameObject letter;

    public void updateMail(Sprite mail)
    {
        letter.getComponent<SpriteRenderer>().sprite = mail;
        letter.SetActive(true);
        return;
    }
}
