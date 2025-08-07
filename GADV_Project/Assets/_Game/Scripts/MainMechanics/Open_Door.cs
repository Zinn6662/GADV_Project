using NUnit.Framework.Constraints;
using UnityEngine;

public class Open_Door : MonoBehaviour
{
    public bool doorOpen = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            GameObject item = playerInventory.GetCurrentItem();
            string color = CheckDoorName(); 
            if (!string.IsNullOrEmpty(color) && item != null && item.name.StartsWith(color + "_Key"))
            {
                playerInventory.RemoveCurrentItem();
                Debug.Log("Removed key item from inventory.");
                gameObject.SetActive(false);
                doorOpen = true;
            }
            else if (!string.IsNullOrEmpty(color) && item != null && item.name.EndsWith("_Key"))
            {
                Debug.Log("Player has a key, but it does not match the door color.");
            }
            else
            {
                Debug.Log("Player does not have any key on hand");
            }
        }
    }

    public string CheckDoorName()
    {
        if (gameObject.name.EndsWith("_Door"))
        {
            string color = gameObject.name.Substring(0, gameObject.name.Length - "_Door".Length);
            if (!string.IsNullOrEmpty(color) && System.Text.RegularExpressions.Regex.IsMatch(color, @"^[A-Za-z]+$"))
            {
                Debug.Log("Door Color: " + color);
                return color;
            }
        }
        return null;
    }
}
