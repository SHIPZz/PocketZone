using Constant;
using Services.DependencyContainer;
using Services.GameFactory;
using UnityEngine;
using UnityEngine.UI;

public class AddItemToItemGroup : MonoBehaviour
{
    private int _inventoryRows = 4; // ���������� ����� � ���������
    private int _inventoryColumns = 5; // ���������� �������� � ���������

    private GameObject[,] _inventoryItems; // ��������� ������

    private GameObject _prefab;

    private VerticalLayoutGroup _verticalLayoutGroup; // ������������ ��������� ��� �����
    private GameFactory _gameFactory;

    private void Start()
    {
        _gameFactory = ServiceLocator.Get<GameFactory>();

        _inventoryItems = new GameObject[_inventoryRows, _inventoryColumns];
        FillInventory();
    }

    private void FillInventory()
    {
        _verticalLayoutGroup = gameObject.AddComponent<VerticalLayoutGroup>(); // ��������� ������������ ���������

        for (int row = 0; row < _inventoryRows; row++)
        {
            HorizontalLayoutGroup horizontalLayoutGroup = gameObject.AddComponent<HorizontalLayoutGroup>(); // ������� ����� HorizontalLayoutGroup ��� ������ ������

            for (int column = 0; column < _inventoryColumns; column++)
            {
                if (column > 0 && column % 5 == 0)
                {
                    // ������� ������ ������ ��� �������� �� ����� ������
                    GameObject emptyObject = new GameObject("Empty");
                    emptyObject.transform.SetParent(horizontalLayoutGroup.transform, false);
                }

                _prefab = _gameFactory.CreateObject(AssetPath.SovietBagImage);
                _prefab.transform.SetParent(horizontalLayoutGroup.transform, false);

                _inventoryItems[row, column] = _prefab;
            }
        }

        // ������������� ������������� ������������ ��������� � �������������� � ������������ �����������
        LayoutRebuilder.ForceRebuildLayoutImmediate(_verticalLayoutGroup.GetComponent<RectTransform>());
    }
}
