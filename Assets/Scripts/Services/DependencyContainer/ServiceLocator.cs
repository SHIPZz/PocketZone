using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.DependencyContainer
{
    public class ServiceLocator
    {
        private  static  Dictionary<Type, object> _values = new Dictionary<Type, object>();

       static ServiceLocator()
        {
            Debug.Log("init");
        }
        
        public static void Register<T>(T t)
        {
            Debug.Log(typeof(T));
            _values[typeof(T)] = t;
        }

        public static T Get<T>()
        {
            return (T) _values[typeof(T)];
        }

    }
}
