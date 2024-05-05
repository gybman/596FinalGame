using UnityEngine;

public class Box : MonoBehaviour
{
    private bool playerInRange = false; // Flag to track if the player is in range to pick up the box
    private bool activated = false; // Flag to track if the box pickup has been activated
    private Rigidbody rb; // Rigidbody component of the box

    [SerializeField]
    private ObjectiveManager om;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check for player input to pick up the box
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && !activated)
        {
            activated = true;
            if (om.StartObjective("Mail"))
            {
                PickUpBox();
                
            }
            else
            {
                Debug.Log("Failed to start objective: Mail");
                activated = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player is in range to pick up the box
            playerInRange = true;
            Debug.Log("Player in range to pick up the box.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player is no longer in range to pick up the box
            playerInRange = false;
        }
    }

    private void PickUpBox()
    {
        // Destroy the box
        Debug.Log("Start");
        DestroyBox();
    }

    // Method to check if the player has the box
    public bool HasBox()
    {
        return !gameObject.activeSelf; // Returns true if the box is inactive (picked up by the player)
    }

    // Method to destroy the box
    public void DestroyBox()
    {
        Destroy(gameObject);
    }
}
