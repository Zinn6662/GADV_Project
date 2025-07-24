using UnityEngine;

public class WinCon : MonoBehaviour
{
    private Collider2D _myCol;
    private GameObject _myGameObject;

    private void Start()
    {
        _myCol = GetComponent<Collider2D>();
        if (_myCol == null)
        {
            Debug.LogError("Collider2D component not found on the GameObject.");
        }
        _myGameObject = gameObject;

        _myGameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You Win!");
            // Here you can add code to handle the win condition, like loading a new scene or showing a win UI
        }
    }

    public void WinConReached()
    {
        gameObject.SetActive(true);
    }
}
