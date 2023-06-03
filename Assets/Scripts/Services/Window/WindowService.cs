using System.Collections.Generic;
using UnityEngine;

namespace Services.Window
{
    public class WindowService
    {
        private readonly List<UI.Window> _windows = new List<UI.Window>();
        private readonly List<UI.Window> _hudWindows = new List<UI.Window>();
        
        public UI.Window GetWindow(WindowTypeId windowTypeId)
        {
            UI.Window window = null;
        
            foreach (var win in _windows)
            {
                if (win.WindowTypeId == windowTypeId)
                    window = win;
            }
        
            return window;
        }
        
        public void CloseAll()
        {
            foreach (var window in _windows)
            {
                window.Close();
            }
        }

        public void OpenWindow(WindowTypeId windowTypeId)
        {
            foreach (var window in _windows)
            {
                if (window.WindowTypeId == windowTypeId)
                {
                    window.Open();
                }
            }
        }

        public void OpenHudWindows()
        {
            CloseAll();
            
            foreach (var window in _hudWindows)
            {
                window.Open();
            }
        }
        
        public void CloseWindow(WindowTypeId windowTypeId)
        {
            foreach (var window in _windows)
            {
                if (window.WindowTypeId == windowTypeId)
                {
                    window.Close();
                }
            }
        }

        public void FillList(IReadOnlyList<UI.Window> windows)
        {
            foreach (var window in windows)
            {
                _windows.Add(window);
                AddHudWindows(window);
            }
            
            Debug.Log(_windows.Count);
            Debug.Log(_hudWindows.Count);
        }

        private void AddHudWindows(UI.Window window)
        {
            if(window.WindowTypeId == WindowTypeId.Health || window.WindowTypeId == WindowTypeId.BulletQuantity || 
               window.WindowTypeId == WindowTypeId.Input)
                _hudWindows.Add(window);
        }
    }
}
      
