using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;
    public float killX;

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x <= killX)
        {
            DestroyImmediate(gameObject);
        }
    }
}
