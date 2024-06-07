using UnityEngine;

public class ControladorGay : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private FoodItem heldItem; // The item currently held by the player
    public Transform holdPoint; // The point where the item will be held

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle player movement input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // Handle player interaction input with the "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void Interact()
    {
        if (heldItem == null)
        {
            // Cast the Raycast slightly in front of the player
            Vector2 raycastOrigin = transform.position + transform.up * 0.15f; // Adjust the offset as needed
            float maxDistance = 0.1f;
            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, transform.up, maxDistance);

            // Visualize the Raycast in the Scene view
            Debug.DrawRay(raycastOrigin, transform.up * maxDistance, Color.green);

            if (hit.collider != null)
            {
                FoodItem foodItem = hit.collider.GetComponent<FoodItem>();
                if (foodItem != null)
                {
                    // Pick up the item
                    heldItem = foodItem;
                    heldItem.transform.SetParent(holdPoint);
                    heldItem.transform.localPosition = Vector2.zero;
                    heldItem.GetComponent<Collider2D>().enabled = false; // Disable the collider to avoid unwanted interactions
                }
            }
        }
        else
        {
            // Try to drop the item into the cooking station
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.5f); // Adjust the radius as needed
            foreach (var hit in hits)
            {
                CookingStation station = hit.GetComponent<CookingStation>();
                if (station != null)
                {
                    // Drop the item into the cooking station
                    heldItem.transform.SetParent(null);
                    heldItem.GetComponent<Collider2D>().enabled = true;
                    heldItem = null;
                    return; // Exit the method once the item is dropped
                }
            }

            // If not near a cooking station, drop the item on the ground
            heldItem.transform.SetParent(null);
            heldItem.GetComponent<Collider2D>().enabled = true;
            heldItem = null;
        }
    }
}
