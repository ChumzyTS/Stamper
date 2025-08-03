using System.CodeDom;
using System.IO;
using UnityEngine;
using TMPro;

public class StampTracker : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public int stamped = 0;
    private int maxStamped = 7;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private Sprite openDoor;

    public void UpdateCounter(int addStamp)
    {
        stamped += addStamp;
        if (stamped >= maxStamped)
        {
            door.GetComponent<SpriteRenderer>().sprite = openDoor;
            door.GetComponent<LoadScreenOnCollision>().open = true;
        }
        counterText.text = stamped.ToString() + "/" + maxStamped.ToString();
    }
}
