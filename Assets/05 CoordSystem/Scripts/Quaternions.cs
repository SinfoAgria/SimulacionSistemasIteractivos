using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quaternions : MonoBehaviour
{
    private void Start()
    {

    }

    private void Update()
    {
        Quaternion q = Quaternion.Euler(0, 0, 5 * Time.deltaTime);
        //transform.rotation;
    }
}
