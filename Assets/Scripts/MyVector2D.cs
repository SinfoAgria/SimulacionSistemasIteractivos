using System;
using UnityEngine;

[Serializable]

struct MyVector2D
{
    public float x;
    public float y;

    public MyVector2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public MyVector2D Sum(MyVector2D a)
    {
        return new MyVector2D(
            this.x + a.x,
            this.y + a.y
            );
    }
    public MyVector2D Sub(MyVector2D a)
    {
        return new MyVector2D(
            this.x - a.x,
            this.y - a.y
            );
    }
    public MyVector2D Scale(float a)
    {
        return new MyVector2D(
            this.x *    a ,
            this.y *    a
            );
    }

    /*public static MyVector2D operator + (MyVector2D a, MyVector2D b)
    {
        return a.Sum(b);
    }

    public static MyVector2D operator - (MyVector2D a, MyVector2D b)
    {
        return a.Sub(b);
    }

    public static MyVector2D operator * (MyVector2D a, float x)
    {
        return a.Scale(x);
    }*/

    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color);
    }

    public override string ToString()
    {
        return $"[{x},{y}]";
    }

    public void Draw(MyVector2D newOrigin, Color color)
    {
        Debug.DrawLine(new Vector3(newOrigin.x, newOrigin.y), new Vector3(newOrigin.x + x, newOrigin.y + y), color);
    }

    public static MyVector2D operator +(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(a.x + b.x, a.y + b.y);
    }

    public static MyVector2D operator -(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(a.x - b.x, a.y - b.y);
    }

    public static MyVector2D operator *(MyVector2D a, float b)
    {
        return new MyVector2D(a.x * b, a.y * b);
    }
}
