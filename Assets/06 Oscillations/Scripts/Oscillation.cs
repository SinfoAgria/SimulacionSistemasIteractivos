using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour
{
    [SerializeField]private float amplitude = 1;
    [SerializeField] private float factor = 1;
    //Vector3 inicialPosition;

    private void Start()
    {
        //inicialPosition = transform.position;
    }

    private void Update()
    {
        float x = amplitude * Mathf.Sin(factor * Time.time);
        transform.position =  new Vector3(x, x, 0);

        //float x = amplitude * Mathf.Sin(2*Mathf.PI * (Time.time/factor));
        //transform.position = inicialPosition +  new Vector3(x, x, 0);

        //float x = Mathf.Sin(10f * Time.time) + Mathf.Cos(Time.time / 3f) + Mathf.Sin(Time.time / 13f) + Mathf.Cos(5f * Time.time);
        //transform.position = inicialPosition + new Vector3(x, 0, 0);
    }
}
