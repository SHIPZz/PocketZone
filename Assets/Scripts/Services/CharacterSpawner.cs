using System;
using Constant;
using GameInit;
using Gameplay;
using Gameplay.Player;
using Services.Databases;
using Services.DependencyContainer;
using Services.Window;
using UI.Health;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services
{
    public class CharacterSpawner : MonoBehaviour
    {
         [field: SerializeField] public ObjectTypeId ObjectTypeId { get; private set; }

        private GameFactory.GameFactory _gameFactory;
        private UICreator _uiCreator;

        private void Awake()
        {
            _gameFactory = ServiceLocator.Get<GameFactory.GameFactory>();
            _uiCreator = ServiceLocator.Get<UICreator>();
        }

        public GameObject Spawn()
        {
            GameObject obj = CreateObject();
            SetPosition(obj);
            CreateHealthbar(obj);
            return obj;
        }

        private GameObject CreateObject()
        {
            switch (ObjectTypeId)
            {
                case ObjectTypeId.Mutant:
                    return _gameFactory.CreateObject(AssetPath.Mutantrefab);

                case ObjectTypeId.Zombie:
                    return _gameFactory.CreateObject(AssetPath.ZombiePrefab);

                case ObjectTypeId.Player:
                    return _gameFactory.CreateObject(AssetPath.PlayerPrefab);
            }

            return null;
        }

        private void SetPosition(GameObject obj)
        {
            obj.transform.position = transform.position;
        }

        private void CreateHealthbar(GameObject obj)
        {
            if (obj.TryGetComponent(out Character character))
            {
                GameObject healthbarPrefab = _uiCreator.CreateHealthbar(character.Health);
               healthbarPrefab.transform.SetParent(WindowDatabase.Get(WindowTypeId.Health).gameObject.transform);
            }
        }
    }
}