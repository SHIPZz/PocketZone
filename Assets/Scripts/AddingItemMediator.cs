using System;
using Constant;
using Gameplay.Player;
using Services.DependencyContainer;
using Services.GameFactory;
using UnityEngine;
using UnityEngine.Serialization;

public class AddingItemMediator : MonoBehaviour
{
    private Player _player;
    private GameFactory _gameFactory;

    private void Start()
    {
        _gameFactory = ServiceLocator.Get<GameFactory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject item = null;

        if (other.gameObject.layer == Constant.Constant.SovietBagLayer)
        {
            item = _gameFactory.CreateObject(AssetPath.SovietBagImage);
        }
    }

    public void SetPlayer(Player player) =>
        _player = player;

    public void SetInventoryManager(InventoryView inventoryView)
    {
        // _inventoryManager = inventoryManager;
    }


    private void ItemFaced(GameObject item)
    {
        
    }
}