using System;
using Constant;
using Gameplay.Enemy;
using Services.DependencyContainer;
using UnityEngine;

namespace Services
{
    public class ItemSpawnerHandler : MonoBehaviour
    {
        [SerializeField] private SpawnObjectTypeId _spawnObjectTypeId;

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
            switch (_spawnObjectTypeId)
            {
                case SpawnObjectTypeId.SovietBag:
                    _item = _gameFactory.CreateObject(AssetPath.SovietBagPrefab);
                    break;
            }


            _item.transform.position = obj;
        }
    }
}