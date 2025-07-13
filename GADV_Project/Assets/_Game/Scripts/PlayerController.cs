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
        Debug.Log("canMove: " + canMove); // Add this line

        if (!canMove)
        {
            return; // Exit early if movement is disabled
        }
        
        Vector2 move = Vector2.zero;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move.x += 1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move.x -= 1f;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            move.y += 1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            move.y -= 1f;
        }

        if (move != Vector2.zero)
        {
            lastMoveDirection = move.normalized; // Update last direction
            move = move.normalized * speed * Time.deltaTime;
            _myRb.MovePosition(_myRb.position + move);
        }
    }
}
