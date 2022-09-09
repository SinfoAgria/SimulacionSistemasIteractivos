using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private MyVector2D position;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;
    [SerializeField] private float mass = 1f;

    [Header("Forces")]
    //[SerializeField] private MyVector2D wind;
    private float gravityNum = -9.8f;

    [Range(0f, 1f), SerializeField] private float DampingFactor = 0.9f;
    [Range(0f, 1f), SerializeField] private float frictioncoefficient = 0.9f;
    [SerializeField] private bool useFluidFriction;

    [Header("World")]
    [SerializeField] Camera cam;
    void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        acceleration = new MyVector2D(0, 0);

        float weightScalar = gravityNum * mass;
        MyVector2D weight = new MyVector2D(0, weightScalar);
        MyVector2D friction = new MyVector2D(0, 0);
        ApplyForce(weight);

        if (useFluidFriction)
        {            
            if(transform.localPosition.y <= 0)
            {
                float frontalArea = transform.localScale.x;
                float rho = 1;
                float fluidDragCoefficient = 1;
                float velocityMagnitude = velocity.magnitude;
                float scalarPart = -0.5f * rho * velocityMagnitude * velocityMagnitude * frontalArea * fluidDragCoefficient;
                MyVector2D frictionWater = scalarPart * velocity.normalized;
                ApplyForce(frictionWater);
            }
        }
        else
        {
            friction = frictioncoefficient * -weightScalar * velocity.normalized * -1;
            ApplyForce(weight + friction);
            weight.Draw(position, Color.cyan);
        }

        //ApplyForce(wind);

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

        if (Mathf.Abs(position.x) > cam.orthographicSize)
        {
            position.x = Mathf.Sign(position.x) * cam.orthographicSize;
            velocity *= -DampingFactor;
        }

        if (Mathf.Abs(position.y) > cam.orthographicSize)
        {
            position.y = Mathf.Sign(position.y) * cam.orthographicSize;
            velocity *= -DampingFactor;
        }

        transform.position = position;
    }

    private void ApplyForce(MyVector2D force)
    {
        acceleration = force / mass;
    }
}
