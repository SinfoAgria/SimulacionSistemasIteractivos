using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practica01 : MonoBehaviour
{
    [SerializeField] MyVector2D myFirstVector = new MyVector2D(-3, 4);
    [SerializeField] MyVector2D mySecondVector = new MyVector2D(3, 4);
    [Range(0,1)][SerializeField] float scalar = 0;

    void Start()
    {

    }

    void Update()
    {       
        MyVector2D diff = (mySecondVector - myFirstVector) * scalar;
        MyVector2D final = diff + myFirstVector;

        diff.Draw(Color.yellow);
        myFirstVector.Draw(Color.red);
        mySecondVector.Draw(Color.blue);
        final.Draw(Color.green);
        diff.Draw(myFirstVector, Color.yellow);
    }
}
