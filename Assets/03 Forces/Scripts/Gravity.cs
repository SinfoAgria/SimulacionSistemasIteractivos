using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private Gravity target;
    public float mass = 1f;

    private MyVector2D position;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;

    void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        acceleration *= 0;

        MyVector2D atrac = target.transform.position - transform.position;
        float atracMagnitude = atrac.magnitude;
        MyVector2D force = atrac.normalized * (target.mass / atracMagnitude * atracMagnitude);
        ApplyForce(force);
        force.Draw(position, Color.magenta);

        Move();
    }

    void Update()
    {
        position.Draw(Color.blue);
        velocity.Draw(position, Color.red);
        acceleration.Draw(position, Color.green);
    }

    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;

        if (velocity.magnitude > 5)
        {
            velocity.Normalized();
            velocity *= 5;
        }

        transform.position = position;
    }

    private void ApplyForce(MyVector2D force)
    {
        acceleration = force / mass;
    }
}
