using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField]
    private float waveSpeed = 1f;
    [SerializeField]
    private int width = 96;
    [SerializeField]
    private GameObject boat;
    [SerializeField]
    private float boatSink = 1;
    [SerializeField]
    private float boatSpeed = 0.2f;

    private Vector3 initBoatPos;
    private int boatDir = -1;

    void Awake()
    {
        initBoatPos = boat.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Waves
        transform.position -= new Vector3(Time.deltaTime * waveSpeed, 0, 0);
        if (transform.position.x <= -width)
        {
            transform.position += new Vector3(width, 0, 0);
        }

        // Boat
        if (boat.transform.position.y < initBoatPos.y - boatSink)
        {
            boatDir = 1;
        }
        if (boat.transform.position.y > initBoatPos.y)
        {
            boatDir = -1;
        }

        boat.transform.position += new Vector3(0, boatDir * Time.deltaTime * boatSpeed, 0);
    }
}
