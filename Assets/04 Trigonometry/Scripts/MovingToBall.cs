using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToBall : MonoBehaviour
{
    private enum MovementMode
    {
        ConstantVelocity = 0,
        Acceleration
    }

    private Vector3 acceleration;
    private Vector3 velocity;

    [SerializeField] private MovementMode movementMode;
    [SerializeField] private float speed;

    private void Update()
    {
        UpdateMovementVector();

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        RotateZ(Mathf.Atan2(velocity.y, velocity.x) - Mathf.PI / 2f);
    }

    private void UpdateMovementVector()
    {
        if (movementMode == MovementMode.ConstantVelocity)
        {
            velocity = GetWorldMousePosition() - transform.position;
            velocity.z = 0;
            velocity.Normalize();
            velocity *= speed;
            acceleration *= 0;
        }
        else if (movementMode == MovementMode.Acceleration)
        {
            acceleration = GetWorldMousePosition() - transform.position;
            velocity.z=0;
        }
    }

    private void LookAtMouse(Vector3 mousePosition)
    {
        Vector3 thisPosition = new Vector2(transform.position.x, transform.position.y);
        Vector3 forward = mousePosition - thisPosition;
        float radians = Mathf.Atan2(forward.y, forward.x) - Mathf.PI / 2;
        RotateZ(radians);
    }

    private Vector3 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    private void RotateZ(float angleRad)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angleRad * Mathf.Rad2Deg);
    }
}
