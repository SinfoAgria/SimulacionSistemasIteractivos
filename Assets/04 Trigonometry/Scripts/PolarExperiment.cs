using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarExperiment : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float angleDeg;

    [Header("Speed n Accelaration")]
    [SerializeField] float angularSpeed;
    [SerializeField] float angularAccel;
    [SerializeField] float radialSpeed;
    [SerializeField] float RadialAccel;

    [Header("World")]
    [SerializeField] Transform esfera;
    [SerializeField] Camera cam;

    private void Start()
    {
        
    }

    private void Update()
    {
        angleDeg += angularSpeed * Time.deltaTime;
        radius += radialSpeed * Time.deltaTime;

        if (Mathf.Abs(radius) > cam.orthographicSize)
        {
            radialSpeed *= -1;
            radius = Mathf.Sign(radius) * cam.orthographicSize;
        }

        esfera.position = PolarToCartesian(radius, angleDeg);
        Debug.DrawLine(Vector3.zero, esfera.position);
    }

    private Vector2 PolarToCartesian(float radius, float angle)
    {
        float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector3(x, y, 0);
    }
}
