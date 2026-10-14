using UnityEngine;
using UnityEngine.InputSystem;

public class Rotating : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 90f, 0f);
    public bool isActive = true;

    void Start()
    {
        Debug.Log("RotatingObstacle is running");
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            isActive = !isActive;
        }

        if (isActive)
        {
            Vector3 rotationThisFrame =
                rotationSpeed * Time.deltaTime;

            transform.Rotate(
                rotationThisFrame
            );
        }
    }
}