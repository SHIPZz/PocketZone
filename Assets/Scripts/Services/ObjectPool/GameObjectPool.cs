using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.ObjectPool
{
    public class GameObjectPool
    {
        private readonly int _additionalSize = 2;

        private Queue<GameObject> _objects = new Queue<GameObject>();

        private Func<GameObject> _objectCreator;

        private int _count;

        public GameObjectPool(Func<GameObject> objectCreator, int count)
        {
            _objectCreator = objectCreator;

            CreateObjects(count);

            _count = count;
        }

        public GameObject Pop()
        {
            if (_objects.Count <= 0)
            {
                CreateObjects(_count * (_additionalSize - 1));
            }

            GameObject obj = _objects.Dequeue();
            obj.SetActive(true);
        
            Debug.Log(_count);

            return obj;
        }

        public void Push(GameObject obj)
        {
            obj.SetActive(false);
            _objects.Enqueue(obj);
        }

        private void CreateObjects(int count)
        {
            for (var i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private void CreateObject()
        {
            GameObject obj = _objectCreator.Invoke();
        
            obj.SetActive(false);

            _count++;
            _objects.Enqueue(obj);
        }
    }
}