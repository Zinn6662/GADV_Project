using UnityEngine;

public class TakeItem : MonoBehaviour
{
    private Collider2D _myCol;
    private bool isTouchingItem = false;
    private GameObject currentItem = null;
    private PlayerInventory playerInventory;
    public bool itemPickedUp = false;

    private void Start()
    {
        _myCol = GetComponent<Collider2D>();
        if (_myCol == null)
        {
            Debug.LogError("Collider2D component not found on the GameObject.");
        }

        playerInventory = GetComponent<PlayerInventory>();
        if (playerInventory == null)
        {
            Debug.LogError("PlayerInventory component not found on the GameObject.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("You are touching an item");
            isTouchingItem = true;
            currentItem = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("You are no longer touching an item!");
            isTouchingItem = false;
            currentItem = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTouchingItem && currentItem != null)
            {
                if (playerInventory != null)
                {
                    if (playerInventory.AddItemToInv(currentItem))
                    {
                        itemPickedUp = true;
                        currentItem.SetActive(false);
                        isTouchingItem = false;
                        currentItem = null;
                        Debug.Log("You pressed E to take the item!");
                        
                    }
                    else
                    {
                        Debug.Log("Cannot pick up item: Inventory is full.");
                    }
                }
            }
            else
            {
                Debug.Log("You need to be touching an item to pick it up!");
            }   
        }
    }
}
