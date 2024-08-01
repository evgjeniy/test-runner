using System;
using System.Collections.Generic;
using System.Linq;

public static class ListExtensions
{
    public static TSource Random<TSource>(this IEnumerable<TSource> source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        
        if (source is not List<TSource> list)
            list = source.ToList();
        
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
}