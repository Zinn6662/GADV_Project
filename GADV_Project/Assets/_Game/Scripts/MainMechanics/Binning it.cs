using Unity.VisualScripting;
using UnityEngine;

public class Binningit : MonoBehaviour
{
    public Progress_Tracker progress_Tracker;
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
            }
            else
            {
                Debug.Log("Player does not have any Trash on hand");
            }
        }
    }
}
