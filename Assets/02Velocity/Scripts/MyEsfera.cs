using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEsfera : MonoBehaviour
{
    private MyVector2D position;
    private int CurrentIndex = 0; 

    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;
    [Range(0f,1f), SerializeField] private float DampingFactor = 0.9f;

    [Header ("World")]
    [SerializeField] Camera cam;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (CurrentIndex)
            {
                case 0:
                    acceleration.x = 9.8f;
                    acceleration.y = 0;
                    CurrentIndex++;
                    break;

                case 1:
                    acceleration.y = 9.8f;
                    acceleration.x = 0;
                    CurrentIndex++;
                    break;

                case 2:
                    acceleration.x = -9.8f;
                    acceleration.y = 0;
                    CurrentIndex++;
                    break;

                case 3:
                    acceleration.y = -9.8f;
                    acceleration.x = 0;
                    CurrentIndex = 0;
                    break;
            }
            velocity *= 0;
        }     
    }

    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;

        if(Mathf.Abs(position.x) > cam.orthographicSize)
        {
            velocity.x *= -1;
            position.x = Mathf.Sign(position.x) * cam.orthographicSize;
            velocity *= DampingFactor;
        }

        if (Mathf.Abs(position.y) > cam.orthographicSize)
        {
            velocity.y *= -1;
            position.y = Mathf.Sign(position.y) * cam.orthographicSize;
            velocity *= DampingFactor;
        }

        transform.position = new Vector3 (position.x, position.y, 0);
    }
}
