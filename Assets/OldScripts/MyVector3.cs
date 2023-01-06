using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MyVector3
{
    float x, y, z;

    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }
    public float Z { get => z; set => z = value; }

    public float SqrtMagnitude => x*x + y*y + z*z;
    public float Magnitude => Mathf.Sqrt(SqrtMagnitude);

    public void Normalize()
    {
        var m = Magnitude;
        x /= m;
        y /= m;
        z /= m;
    }

    public static MyVector3 operator+(MyVector3 left, MyVector3 right)
    {
        return new MyVector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        //var resultat = Vector2.zero + Vector3.zero;
    }

    public static MyVector3 operator*(MyVector3 left, float right)
    {
        return new MyVector3(left.X * right, left.Y*right, left.Z*right);
    }


    public MyVector3(float X, float Y, float Z)
    {
        x = X;
        y = Y;
        z = Z;

    }
}
