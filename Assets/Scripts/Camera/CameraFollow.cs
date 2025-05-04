using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    [SerializeField]private float cameraHalfWidth;
    [SerializeField]private float cameraHalfHeight;

    void Start()
    {
        Camera cam = Camera.main;
    }
    void Update()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        float clampedX = Mathf.Clamp(desiredPosition.x, minPosition.x + cameraHalfWidth, maxPosition.x - cameraHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minPosition.x + cameraHalfHeight, maxPosition.y - cameraHalfHeight);

        Vector3 finalPosition = new Vector3(clampedX, clampedY, desiredPosition.z);
        transform.position = Vector3.Lerp(transform.position, finalPosition, smoothSpeed);
    }
}
