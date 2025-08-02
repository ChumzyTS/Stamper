using Microsoft.Unity.VisualStudio.Editor;
using Unity.Mathematics;
using UnityEngine;

public class SailIn : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Animator fader;
    
    private PlayerMovement playerMovement;

    [SerializeField]
    private GameObject boat;


    [SerializeField]
    private Vector2 startPos;
    [SerializeField]
    private Vector2 endPos;
    [SerializeField]
    private float sailInTime;
    private float currentSailInTime;

    private Vector2 playerOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        fader.SetTrigger("FadeIn");
        currentSailInTime = sailInTime;
        playerMovement = player.GetComponent<PlayerMovement>();

        playerOffset = player.transform.position - boat.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSailInTime > 0)
        {
            currentSailInTime -= Time.deltaTime;
            boat.transform.position = Vector3.Lerp(startPos, endPos, 1 - currentSailInTime / sailInTime);
            player.transform.position = boat.transform.position + (Vector3)playerOffset;
            playerMovement.enabled = false;
        }
        else
        {
            boat.transform.position = endPos;
            player.transform.position = endPos + playerOffset;
            playerMovement.enabled = true;
            DestroyImmediate(this);
        }
    }
}
