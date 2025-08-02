using UnityEngine;

public class FPrompt : MonoBehaviour
{
    public GameObject prompt;
    public GameObject player;

    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject == player)
        {
            prompt.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject == player)
        {
            prompt.SetActive(false);
        }
    }
}
