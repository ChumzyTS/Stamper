using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Vector3 cameraOffset;

    [SerializeField]
    private Vector2 bottomLeft;
    [SerializeField]
    private Vector2 topRight;

    void Awake()
    {
        // Convert Bounds to Camera Size
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * 16 / 9;

        bottomLeft += new Vector2(halfWidth, halfHeight);
        topRight -= new Vector2(halfWidth, halfHeight);
    }

    void Update()
    {
        Vector3 cameraPos = new Vector3(
            Math.Clamp(transform.position.x + cameraOffset.x, bottomLeft.x, topRight.x),
            Math.Clamp(transform.position.y + cameraOffset.x, bottomLeft.y, topRight.y),
            cameraOffset.z
        );
        cam.transform.position = cameraPos;
    }
}
