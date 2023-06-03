using Constant;
using Gameplay.Enemy;
using Services.Databases;
using Services.DependencyContainer;
using UnityEngine;

namespace Services
{
    public class ItemSpawnerHandler : MonoBehaviour
    {
         [SerializeField] private ObjectTypeId _objectTypeId;
        
        private EnemyDestruction _enemyDestruction;
        private GameFactory.GameFactory _gameFactory;

        private GameObject _item;

        private void Awake()
        {
            _enemyDestruction = GetComponentInParent<EnemyDestruction>();
            _gameFactory = ServiceLocator.Get<GameFactory.GameFactory>();
            
            Spawn();
        }

        private void OnEnable()
        {
            _enemyDestruction.Destroyed += SetItemPosition;
        }
        
        private void OnDisable()
        {
            _enemyDestruction.Destroyed -= SetItemPosition;
        }

        private void SetItemPosition(Vector3 targetPosition)
        {
            _item.transform.position = targetPosition;
            _item.gameObject.SetActive(true);
        }

        private void Spawn()
        {
            switch (_objectTypeId)
            {
                case ObjectTypeId.SovietBag:
                    _item = _gameFactory.CreateObject(AssetPath.SovietBagPrefab);
                    break;
            }

            _item.gameObject.SetActive(false);
            DynamicItemDatabase.Add(_item.GetComponent<DynamicItem>());
        }
    }
}