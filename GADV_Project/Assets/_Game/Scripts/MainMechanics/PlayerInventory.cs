using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private GameObject inventoryItem = null;
    private PlayerController PlayerController;
    public bool itemDropped = false; // Flag to indicate if an item has been dropped

    void Start()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // Placeholder for inventory key input
        {
            GetCurrentItem();
        }
        if (Input.GetKeyDown(KeyCode.Q)) // Placeholder for remove item key input
        {
            itemDropped = true; // Set the flag to true when an item is dropped
            StartCoroutine(DropItemWithDelay());
        }
    }

    public bool AddItemToInv(GameObject item)
    {
        if (inventoryItem != null)
        {
            Debug.LogWarning("Inventory already has an item.");
            return false;
        }
        else
        {
            inventoryItem = item;
            Debug.Log($"Added {item.name} to inventory.");
            return true;
        }
    }

    public void DropCurrentItem()
    {
        if (inventoryItem != null)
        {
            // Offset the item 1 unit to the right of the player
            Vector2 dropDirection = PlayerController.LastMoveDirection; // Safe, read-only access
            inventoryItem.transform.position = transform.position + (Vector3)dropDirection;
            inventoryItem.SetActive(true);
            Debug.Log($"{inventoryItem.name} has been removed from your inventory.");
            inventoryItem = null;
        }
        else
        {
            Debug.Log("Inventory is already empty.");
        }
    }

    public void RemoveCurrentItem()
    {
        if (inventoryItem != null)
        {
            Destroy(inventoryItem); 
            Debug.Log($"{inventoryItem.name} has been removed.");
            inventoryItem = null;
        }
        else
        {
            Debug.Log("Inventory is empty.");
        }
    }

    public GameObject GetCurrentItem()
    {
        if (inventoryItem != null)
        {
            Debug.Log($"Current Inventory Item: {inventoryItem.name}");
            return inventoryItem;
        }
        else
        {
            Debug.Log("Inventory is empty.");
            return null;    
        }
    }

    private System.Collections.IEnumerator DropItemWithDelay()
    {
        yield return new WaitForSeconds(0.1f); 
        DropCurrentItem();
    }
}
