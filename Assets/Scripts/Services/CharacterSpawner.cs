using System;
using Constant;
using GameInit;
using Gameplay;
using Gameplay.Player;
using Services.DependencyContainer;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services
{
    public class CharacterSpawner : MonoBehaviour
    {
         [field: SerializeField] public SpawnObjectTypeId SpawnObjectTypeId { get; private set; }

        private GameFactory.GameFactory _gameFactory;
        private UICreator _uiCreator;
        private GameObject _parent;
        private Player _player;

        private void Awake()
        {
            CharacterSpawnerDatabase.Add(this);
        }

        private void Start()
        {
            _gameFactory = ServiceLocator.Get<GameFactory.GameFactory>();
            _uiCreator = ServiceLocator.Get<UICreator>();

            GameObject obj = CreateObject();
            
            SetPosition(obj);
            CreateHealthbar(obj);
        }

        private GameObject CreateObject()
        {
            switch (SpawnObjectTypeId)
            {
                case SpawnObjectTypeId.Mutant:
                    return _gameFactory.CreateObject(AssetPath.Mutantrefab);

                case SpawnObjectTypeId.Zombie:
                    return _gameFactory.CreateObject(AssetPath.ZombiePrefab);

                case SpawnObjectTypeId.Player:
                    var player = _gameFactory.CreateObject(AssetPath.PlayerPrefab);
                    _player = player.GetComponent<Player>();
                    return player;
            }

            return null;
        }

        public Player GetPlayer() =>
            _player;
        
        public void SetParentForHealthbar(GameObject parent)
        {
            _parent = parent;
        }

        private void SetPosition(GameObject obj)
        {
            obj.transform.position = transform.position;
        }

        private void CreateHealthbar(GameObject obj)
        {
            if (obj.TryGetComponent(out ICharacter character))
            {
                GameObject gameObject = _uiCreator.CreateHealthbar(character.Health, character);
               gameObject.transform.SetParent(_parent.transform);
            }
        }
    }
}