using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject _itemGroupPrefab;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Button _button;

    private int _itemsPerGroup = 7;

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

    private void OnEnable()
    {
        _button.onClick.AddListener(AddItemToInventory);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(AddItemToInventory);
    }

    public void AddItemToInventory()
    {
        GameObject item = Instantiate(_itemPrefab);

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
}