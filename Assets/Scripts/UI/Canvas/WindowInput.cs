// using System.Collections.Generic;
// using Services.DependencyContainer;
// using Services.Window;
// using UI;
// using UnityEngine;
// using UnityEngine.Serialization;
// using UnityEngine.UI;
//
// public class WindowInput : MonoBehaviour
// {
//     private WindowService _windowService;
//     
//     public Button InventoryOpenButton { get; set; }
//     public Button CloseInventoryButton { get; set; }
//
//     private void Awake()
//     {
//         _windowService = ServiceLocator.Get<WindowService>();
//     }
//
//     private void OnEnable()
//     {
//         InventoryOpenButton.onClick.AddListener(OnOpenButtonClicked);
//         CloseInventoryButton.onClick.AddListener(OnCloseButtonClicked);
//     }
//     
//     private void OnDisable()
//     {
//         CloseInventoryButton.onClick.RemoveListener(OnCloseButtonClicked);
//         InventoryOpenButton.onClick.RemoveListener(OnOpenButtonClicked);
//     }
//     
//     private void OnCloseButtonClicked()
//     {
//         _windowService.OpenWindow(WindowTypeId.Input);
//         _windowService.OpenWindow(WindowTypeId.Health);
//     }
//     
//     private void OnOpenButtonClicked()
//     {
//         _windowService.OpenWindow(WindowTypeId.Inventory);
//     }
// }