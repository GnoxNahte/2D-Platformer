using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public  static class MathExtensions 
{
    // Divide by this to prevent infinity
    const float MinDivision = 1e-3f;

    public static readonly Vector2 Vector2MinDivision = new Vector2(MinDivision, MinDivision);
    public static Vector2 Floor(Vector2 v) => new Vector2(Mathf.Floor(v.x), Mathf.Floor(v.y));


}
