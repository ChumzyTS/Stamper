using UnityEngine;

public class Belay : MonoBehaviour
{
    [Header("Belay Detection")]

    public GameObject player;
    public PlayerMovement pScript;
    public Sprite StampedSign;
    public Sprite UnstampedSign;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Belay Collision
    public void OnTriggerEnter2D(Collider2D trigger)
    {


        
        if (trigger.gameObject == player)
        {
            if (pScript.respawnAnchor != gameObject)
            {
                if (pScript.respawnAnchor != null)
                {
                    Debug.Log(pScript.respawnAnchor.GetComponent<SpriteRenderer>().sprite);
                    pScript.respawnAnchor.GetComponent<SpriteRenderer>().sprite = UnstampedSign;
                }
                
                // changes this sign
                pScript.respawnAnchor = gameObject;
                GetComponent<SpriteRenderer>().sprite = StampedSign;
            }
            

        }

        

    }
}
