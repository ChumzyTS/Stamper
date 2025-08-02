using Unity.Mathematics;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField]
    private Sprite[] clouds;

    [SerializeField]
    private Vector2 scaleRange;

    [SerializeField]
    private Vector2 timeRange;
    private float waitTime;

    [SerializeField]
    private Vector2 heightRange;
    [SerializeField]
    private float xPos;

    [SerializeField]
    private Vector2 speedRange;

    [SerializeField]
    private float killX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateCloud();
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            GenerateCloud();
        }
    }

    private void GenerateCloud()
    {
        float scale = math.lerp(scaleRange.x, scaleRange.y, UnityEngine.Random.Range(0f, 1f));
        float height = math.lerp(heightRange.x, heightRange.y, UnityEngine.Random.Range(0f, 1f));
        float speed = math.lerp(speedRange.x, speedRange.y, UnityEngine.Random.Range(0f, 1f));
        Sprite cloudSprite = clouds[UnityEngine.Random.Range(0, clouds.Length)];

        GameObject cloudObj = new GameObject("Cloud");

        SpriteRenderer spriteRenderer = cloudObj.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = cloudSprite;
        spriteRenderer.sortingLayerName = "Background";
        spriteRenderer.sortingOrder = -5;

        Cloud cloud = cloudObj.AddComponent<Cloud>();
        cloud.killX = killX;
        cloud.speed = speed;
        cloud.transform.position = new Vector3(xPos, height, 0);
        cloud.transform.localScale = new Vector3(scale, scale, 1);

        waitTime = math.lerp(timeRange.x, timeRange.y, UnityEngine.Random.Range(0f, 1f));
    }
}
