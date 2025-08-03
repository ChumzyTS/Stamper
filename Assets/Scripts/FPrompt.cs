using System.Collections;
using UnityEngine;

public class FPrompt : MonoBehaviour
{
    public GameObject prompt;
    public GameObject player;
    public GameObject dialogueBox;
    public bool colliding;

    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject == player)
        {
            prompt.SetActive(true);
            colliding = true;
        }
    }

    public void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject == player)
        {
            prompt.SetActive(false);
            colliding = false;
        }
    }

    public void Update()
    {
        Debug.Log(dialogueBox.activeSelf);
        if ((Input.GetKeyDown(KeyCode.F) && colliding) && dialogueBox.activeSelf == false)
        {

            prompt.SetActive(false);
            StopAllCoroutines();
            gameObject.GetComponent<FriendDialogue>().RunDialogue();
        }

        if (colliding)
        {
            StartCoroutine(PlayerHint());
        }
        else { StopAllCoroutines(); }
    }

    IEnumerator PlayerHint()
    {
        yield return new WaitForSecondsRealtime(10);
        prompt.SetActive(true);
    }
}
