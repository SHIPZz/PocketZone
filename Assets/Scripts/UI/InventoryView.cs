using UI;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject _itemGroupPrefab;

    private readonly int _itemsPerGroup = 7;
    
    private GameObject _scrollView;
    private GameObject _content;
    private GameObject _currentGroup;
    private int _itemCount;

    private void Start()
    {
        _scrollView = transform.parent.gameObject;
        _content = _scrollView.transform.GetChild(0).gameObject;
        _itemCount = 0;
    }

    public void AddToLayoutGroup(GameObject item)
    {
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

    public void RemoveFromLayoutGroup(Item item)
    {
        // foreach (Transform groupTransform in _content.transform)
        // {
        //     for (int i = 0; i < groupTransform.childCount; i++)
        //     {
        //         Transform itemTransform = groupTransform.GetChild(i);
        //         
        //         if (itemTransform.gameObject == item.gameObject)
        //         {
        //             Destroy(itemTransform.gameObject);
        //             _itemCount--;
        //             return;
        //         }
        //     }
        // }
    }
}