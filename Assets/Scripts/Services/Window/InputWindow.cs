// using Services.DependencyContainer;
// using UnityEngine;
//
// namespace Services.Window
// {
//     public class InputWindow : WindowBase
//     {
//         private Canvas _canvas;
//         private WindowService _windowService;
//
//         private void Awake()
//         {
//             _canvas = GetComponent<Canvas>();
//             _windowService = ServiceLocator.Get<WindowService>();
//             _windowService.RegisterWindow<InputWindow>(WindowTypeId.Input);
//             SetEnable(true);
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