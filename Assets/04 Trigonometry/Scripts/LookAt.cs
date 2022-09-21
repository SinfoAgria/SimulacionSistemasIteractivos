using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mousePosition = GetWorldMousePosition();
        //float angle = Mathf.Atan2(mousePosition.y, mousePosition.x);
        //RotateZ(angle);
        LookAtMouse(mousePosition);
    }

    private void LookAtMouse(Vector3 mousePosition)
    {
        Vector3 thisPosition = new Vector2(transform.position.x, transform.position.y);
        Vector3 forward = mousePosition - thisPosition;
        float radians = Mathf.Atan2(forward.y, forward.x) - Mathf.PI / 2;
        RotateZ(radians);
    }

    private Vector4 GetWorldMousePosition()
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
