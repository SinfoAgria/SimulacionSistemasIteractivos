using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargantua : MonoBehaviour
{
    private MyVector2D position;

    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;

    [Header("World")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform gargantua;
    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        position.Draw(Color.blue);
        velocity.Draw(position, Color.red);
        acceleration.Draw(position, Color.green);

        MyVector2D myPosition = new MyVector2D(transform.position.x, transform.position.y);
        MyVector2D gargantuaPosition = new MyVector2D(gargantua.position.x, gargantua.position.y);
        acceleration = gargantuaPosition - myPosition;

    }

    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;

        transform.position = new Vector3(position.x, position.y, 0);
    }
}
