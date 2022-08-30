using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEsferaWithForces : MonoBehaviour
{
    private MyVector2D vectorPosition;
    private MyVector2D displacement;

    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D force;
    [SerializeField] MyVector2D acceleration;
    [SerializeField] float mass = 1f;

    float timer;

    [Header("World")]
    [SerializeField] new Camera camera;
    [Range(0f, 1f)] float dampingFactor;

    void Start()
    {
        vectorPosition = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        ApplyForce(force);
        Move();
    }

    void Update()
    {
        vectorPosition.Draw(Color.blue);
        velocity.Draw(vectorPosition, Color.red);
        acceleration.Draw(vectorPosition, Color.green);
    }

    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        vectorPosition = vectorPosition + velocity * Time.fixedDeltaTime;

        if (Mathf.Abs(vectorPosition.x) > camera.orthographicSize)
        {
            velocity.x *= -1;
            vectorPosition.x = Mathf.Sign(vectorPosition.x) * camera.orthographicSize;
            velocity *= dampingFactor;
        }

        if (Mathf.Abs(vectorPosition.y) > camera.orthographicSize)
        {
            velocity.y *= -1;
            vectorPosition.y = Mathf.Sign(vectorPosition.y) * camera.orthographicSize;
            velocity *= dampingFactor;
        }

        transform.position = new Vector3(vectorPosition.x, vectorPosition.y, 0);
    }

    private void ApplyForce(MyVector2D force)
    {
        acceleration = force / mass;
    }

    
}
