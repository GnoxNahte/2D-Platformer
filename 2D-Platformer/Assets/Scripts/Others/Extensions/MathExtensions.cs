using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public  static class MathExtensions 
{
    public static readonly Vector2 Vector2Epsilon = new Vector2(Mathf.Epsilon, Mathf.Epsilon);
    public static Vector2 Floor(Vector2 v) => new Vector2(Mathf.Floor(v.x), Mathf.Floor(v.y));


}
