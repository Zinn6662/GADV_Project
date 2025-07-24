using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _myRb;
    private float speed = 10f;

    // Adding a Flag
    public bool canMove = true; 

    // Store the last non-zero movement direction
    private Vector2 lastMoveDirection = Vector2.right; // Default facing right
    public Vector2 LastMoveDirection => lastMoveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        _myRb = GetComponent<Rigidbody2D>();
        if (_myRb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the GameObject.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;

        float moveX = Input.GetAxisRaw("Horizontal"); // Left/Right or A/D
        float moveY = Input.GetAxisRaw("Vertical");   // Up/Down or W/S
        Vector2 move = new Vector2(moveX, moveY);

        if (move != Vector2.zero)
        {
            lastMoveDirection = move.normalized;
            move = move.normalized * speed * Time.deltaTime;
            _myRb.MovePosition(_myRb.position + move);
        }
    }
}
