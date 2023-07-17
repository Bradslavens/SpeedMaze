using UnityEngine;

public class PlayerBackWallCheck : MonoBehaviour
{
    public RectTransform backWallRectTransform;
    public Camera mainCamera;

    void Update()
    {
        // Convert the player's position to screen coordinates
        Vector3 playerScreenPosition = mainCamera.WorldToScreenPoint(transform.position);

        // Check if the player's Y position on the screen is less than or equal to the back wall's Y position on the screen
        if (playerScreenPosition.y <= backWallRectTransform.position.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collission");

        if (collision.collider.CompareTag("BreadCrumb"))
        {
            Destroy(collision.gameObject);
        }
    }
}
