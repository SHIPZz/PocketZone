using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T>
{
    private Queue<GameObject> _bullets = new Queue<GameObject>();

    public ObjectPool(Func<GameObject> objectCreator, int count)
    {
        if (objectCreator == null)
            return;

        for (int i = 0; i < count; i++)
        {
            GameObject bullet = objectCreator.Invoke();

            if (bullet == null)
            {
                Debug.LogWarning("Не удалось создать объект для пула.");
                continue;
            }

            _bullets.Enqueue(bullet);
        }
    }

    public GameObject Get()
    {
        Debug.Log(_bullets.Count);
        
        if (_bullets.Count <= 0)
        {
            Debug.LogWarning("Нет доступных пуль в пуле.");
            return null;
        }

        var bullet = _bullets.Dequeue();
        bullet.SetActive(true);

        Debug.Log(_bullets.Count);
        return bullet;
    }

    public void Return(GameObject bullet)
    {
        if (bullet == null)
            return;

        bullet.SetActive(false);
        _bullets.Enqueue(bullet);
    }
}