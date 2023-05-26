using System;
using Constant;
using Services.DependencyContainer;
using UnityEngine;

namespace Services
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnObjectTypeId _spawnObjectTypeId;
        
        private GameFactory.GameFactory _gameFactory;

        private GameObject _object;

        private void Start()
        {
            _gameFactory = ServiceLocator.Get<GameFactory.GameFactory>();
            
            switch (_spawnObjectTypeId)
            {
                case SpawnObjectTypeId.Mutant:
                    _object =  _gameFactory.CreateObject(AssetPath.Mutantrefab);
                    break;
                
                case SpawnObjectTypeId.Zombie:
                    _object =  _gameFactory.CreateObject(AssetPath.ZombiePrefab);
                    break;
            }

            SetInitialPosition();
        }

        private void SetInitialPosition()
        {
            _object.transform.position = transform.position;
        }
    }
}