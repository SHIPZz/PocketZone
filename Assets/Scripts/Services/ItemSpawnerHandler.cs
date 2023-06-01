using System;
using Constant;
using Gameplay.Enemy;
using Services.DependencyContainer;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services
{
    public class ItemSpawnerHandler : MonoBehaviour
    {
        [FormerlySerializedAs("_spawnObjectTypeId")] [SerializeField] private ObjectTypeId objectTypeId;
        
        private EnemyDestruction _enemyDestruction;
        private GameFactory.GameFactory _gameFactory;

        private GameObject _item;

        private void Awake()
        {
            _enemyDestruction = GetComponentInParent<EnemyDestruction>();
            _gameFactory = ServiceLocator.Get<GameFactory.GameFactory>();
        }

        private void OnEnable()
        {
            _enemyDestruction.Destroyed += Spawn;
        }
        
        private void OnDisable()
        {
            _enemyDestruction.Destroyed -= Spawn;
        }

        private void Spawn(Vector3 obj)
        {
            switch (objectTypeId)
            {
                case ObjectTypeId.SovietBag:
                    _item = _gameFactory.CreateObject(AssetPath.SovietBagPrefab);
                    break;
            }


            _item.transform.position = obj;
        }
    }
}