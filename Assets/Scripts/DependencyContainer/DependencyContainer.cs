using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyContainer : MonoBehaviour
{
    private  static  Dictionary<Type, object> _values = new Dictionary<Type, object>();
    
    public static void Register<T>(T t)
    {
        _values[typeof(T)] = t;
    }

    public static T Get<T>()
    {
        return (T) _values[typeof(T)];
    }

}
