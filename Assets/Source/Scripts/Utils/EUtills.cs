using System.Collections.Generic;
using UnityEngine;

public static class EUtills
{
    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
