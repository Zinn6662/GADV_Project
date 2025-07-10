using UnityEngine;

public class WinCon : MonoBehaviour
{
    private Collider2D _myCol;

    private void Start()
    {
        _myCol = GetComponent<Collider2D>();
        if (_myCol == null)
        {
            Debug.LogError("Collider2D component not found on the GameObject.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WinCon"))
        {
            Debug.Log("You Win!");
            // Here you can add code to handle the win condition, like loading a new scene or showing a win UI
        }
    }
}
