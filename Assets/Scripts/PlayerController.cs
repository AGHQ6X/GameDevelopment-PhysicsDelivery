using UnityEngine;

using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public ActiveManager manager;

    private Rigidbody rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = GameObject.FindWithTag("GameController").GetComponent<ActiveManager>();
    }

    void Update()
    {
        if (manager.active == null)
        {
            moveInput = Vector2.zero;
            return;
        }

        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.aKey.isPressed)
            horizontal = -1f;

        if (Keyboard.current.dKey.isPressed)
            horizontal = 1f;

        if (Keyboard.current.sKey.isPressed)
            vertical = -1f;

        if (Keyboard.current.wKey.isPressed)
            vertical = 1f;

        moveInput =
            new Vector2(horizontal, vertical);
    }

    void FixedUpdate()
    {
        if (manager.active == null)
            return;

        Vector3 movement =
            new Vector3(
                moveInput.x,
                0f,
                moveInput.y
            );

        movement = movement.normalized;

        rb.MovePosition(
            rb.position +
            movement *
            moveSpeed *
            Time.fixedDeltaTime
        );
    }

    public void ResetPlayer()
    {
        Transform resetPoint = GameObject.FindWithTag("ResetPoint").GetComponent<Transform>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.position = resetPoint.position;
            rb.rotation = resetPoint.rotation;
        }
    }
}
