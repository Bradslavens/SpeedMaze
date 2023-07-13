using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 90.0f;
    public float forwardSpeed = 3.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RotateCamera();
        }

        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            Vector3 newPosition = transform.position + new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        // Move the camera forward along its own Y-axis
        transform.position += transform.up * forwardSpeed * Time.deltaTime;
    }

    void RotateCamera()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        float targetRotation = (currentRotation + rotationSpeed) % 360;

        // Snap to the target rotation instantly.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetRotation));
    }
}
