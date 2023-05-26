using Constant;
using Services.DependencyContainer;
using Services.GameFactory;
using UnityEngine;
using UnityEngine.UI;

public class AddItemToItemGroup : MonoBehaviour
{
    private int _inventoryRows = 4; // Количество строк в инвентаре
    private int _inventoryColumns = 5; // Количество столбцов в инвентаре

    private GameObject[,] _inventoryItems; // Двумерный массив

    private GameObject _prefab;

    private VerticalLayoutGroup _verticalLayoutGroup; // Вертикальный контейнер для строк
    private GameFactory _gameFactory;

    private void Start()
    {
        _gameFactory = ServiceLocator.Get<GameFactory>();

        _inventoryItems = new GameObject[_inventoryRows, _inventoryColumns];
        FillInventory();
    }

    private void FillInventory()
    {
        _verticalLayoutGroup = gameObject.AddComponent<VerticalLayoutGroup>(); // Добавляем вертикальный контейнер

        for (int row = 0; row < _inventoryRows; row++)
        {
            HorizontalLayoutGroup horizontalLayoutGroup = gameObject.AddComponent<HorizontalLayoutGroup>(); // Создаем новый HorizontalLayoutGroup для каждой строки

            for (int column = 0; column < _inventoryColumns; column++)
            {
                if (column > 0 && column % 5 == 0)
                {
                    // Создаем пустой объект для переноса на новую строку
                    GameObject emptyObject = new GameObject("Empty");
                    emptyObject.transform.SetParent(horizontalLayoutGroup.transform, false);
                }

                _prefab = _gameFactory.CreateObject(AssetPath.SovietBagImage);
                _prefab.transform.SetParent(horizontalLayoutGroup.transform, false);

                _inventoryItems[row, column] = _prefab;
            }
        }

        // Принудительно перестраиваем расположение элементов в горизонтальных и вертикальных компоновках
        LayoutRebuilder.ForceRebuildLayoutImmediate(_verticalLayoutGroup.GetComponent<RectTransform>());
    }
}
