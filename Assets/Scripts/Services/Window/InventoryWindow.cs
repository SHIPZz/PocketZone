// using System;
// using Services.DependencyContainer;
// using UnityEngine;
//
// namespace Services.Window
// {
//     public class InventoryWindow : WindowBase
//     {
//         private Canvas _canvas;
//         private WindowService _windowService;
//
//         private void Awake()
//         {
//             _canvas = GetComponent<Canvas>();
//             _windowService = ServiceLocator.Get<WindowService>();
//             _windowService.RegisterWindow<InventoryWindow>(WindowTypeId.Inventory);
//             SetEnable(false);
//         }
//
//         public override void OnOpen()
//         {
//             SetEnable(true);
//         }
//
//         public override void OnClose()
//         {
//             SetEnable(false);
//         }
//
//         private void SetEnable(bool isEnable) =>
//             _canvas.enabled = isEnable;
//     }
// }