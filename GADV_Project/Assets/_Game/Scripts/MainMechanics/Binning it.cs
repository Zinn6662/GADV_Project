using Unity.VisualScripting;
using UnityEngine;

public class Binningit : MonoBehaviour
{
    public Progress_Tracker progress_Tracker;
    public bool isTrashBinned = false; // Flag to check if the bin is active
    void Start()
    {
        progress_Tracker = GetComponent<Progress_Tracker>();
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            GameObject item = playerInventory.GetCurrentItem();
            if (item != null && item.name.StartsWith("Trash"))
            {
                playerInventory.RemoveCurrentItem();
                Debug.Log("Removed trash item from inventory.");
                progress_Tracker.AddProgress(); // Increment progress when trash is removed
                isTrashBinned = true; // Set the flag to indicate trash has been binned 
                gameObject.SetActive(false); // Disable the bin after use
            }
            else
            {
                Debug.Log("Player does not have any Trash on hand");
            }
        }
    }
}
