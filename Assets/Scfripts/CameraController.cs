using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 90.0f;

    private float targetRotation;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RotateCamera());
        }

        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            Vector3 newPosition = transform.position + new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }

    IEnumerator RotateCamera()
    {
        float elapsedTime = 0f;
        float currentRotation = transform.rotation.eulerAngles.z;
        targetRotation = (currentRotation + rotationSpeed) % 360;

        while (elapsedTime < 1f)
        {
            float zRotation = Mathf.Lerp(currentRotation, targetRotation, elapsedTime);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Snap to the target rotation after the loop.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetRotation));
    }
}
