using System;
using Services.DependencyContainer;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject _itemGroupPrefab;

    private readonly int _itemsPerGroup = 7;

    private InventoryPresenter _inventoryPresenter;
    private GameObject _scrollView;
    private GameObject _content;
    private GameObject _currentGroup;
    private int _itemCount;

    private void Start()
    {
        _scrollView = transform.parent.gameObject;
        _content = _scrollView.transform.GetChild(0).gameObject;
        _inventoryPresenter.ItemAdded += AddToLayoutGroup;
        _inventoryPresenter.ItemRemoved += RemoveFromLayoutGroup;
        _itemCount = 0;
    }

    private void OnDisable()
    {
        _inventoryPresenter.ItemRemoved -= RemoveFromLayoutGroup;
        _inventoryPresenter.ItemAdded -= AddToLayoutGroup;
    }

    public void AddToLayoutGroup(DynamicItem dynamicItem)
    {
        GameObject item = dynamicItem.gameObject;

        if (_currentGroup == null || _itemCount % _itemsPerGroup == 0)
        {
            _currentGroup = CreateItemGroup();
        }

        item.transform.SetParent(_currentGroup.transform, false);

        _itemCount++;

        LayoutRebuilder.ForceRebuildLayoutImmediate(_content.GetComponent<RectTransform>());
    }

    private GameObject CreateItemGroup()
    {
        GameObject itemGroup = Instantiate(_itemGroupPrefab, _content.transform);
        HorizontalLayoutGroup horizontalLayoutGroup = itemGroup.GetComponent<HorizontalLayoutGroup>();
        horizontalLayoutGroup.childAlignment = TextAnchor.MiddleLeft;
        LayoutRebuilder.ForceRebuildLayoutImmediate(horizontalLayoutGroup.GetComponent<RectTransform>());

        return itemGroup;
    }

    public void RemoveFromLayoutGroup(DynamicItem dynamicItem)
    {
        GameObject item = dynamicItem.gameObject;
        
        foreach (Transform groupTransform in _content.transform)
        {
            for (int i = 0; i < groupTransform.childCount; i++)
            {
                Transform itemTransform = groupTransform.GetChild(i);
                
                if (itemTransform.gameObject == item)
                {
                    Destroy(itemTransform.gameObject);
                    _itemCount--;
                    return;
                }
            }
        }
    }

    public void SetInventoryPresenter(InventoryPresenter inventoryPresenter) =>
        _inventoryPresenter = inventoryPresenter;
}