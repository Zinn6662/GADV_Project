using Unity.VisualScripting;
using UnityEngine;

public class Binningit : MonoBehaviour
{
       void Start()
    {
        Debug.Log("Binningit script started. Waiting for player to collide with trash.");
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
                //UpdateScore();
            }
            else
            {
                Debug.Log("Player does not have any Trash on hand");
            }
        }
    }
}
