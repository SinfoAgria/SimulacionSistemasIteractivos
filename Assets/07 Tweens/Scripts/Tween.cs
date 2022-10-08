using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    [Header("Tween related")]
    [SerializeField, Range(0, 1)]
    private float normalizedTime;
    [SerializeField]
    private float duration = 1;
    [Header("Parameters")]
    [SerializeField]
    private Color initialColor;
    [SerializeField]
    private Color finalColor;

    private float currentTime = 0;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartTween();
    }

    private void Update()
    {
        normalizedTime = currentTime / duration;
        transform.position = Vector3.Lerp(initialPosition, finalPosition, EaseInCubic(normalizedTime));
        spriteRenderer.color = Color.Lerp(initialColor, finalColor, EaseInCubic(normalizedTime));

        /*if (normalizedTime >= 1){
            Debug.Log("Completed");
        }*/

        if (Input.GetKeyDown(KeyCode.Space)) StartTween();
    }

    private void StartTween()
    {
        currentTime = 0f;
        initialPosition = transform.position;
        finalPosition = targetTransform.position;
    }

    private float EaseInCubic(float x)
    {
        return x * x * x;
    }
}
