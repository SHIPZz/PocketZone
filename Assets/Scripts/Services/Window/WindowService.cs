using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Window
{
    public class WindowService
    {
        private readonly List<UI.Window> _windows = new List<UI.Window>();
        
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
        
        public void OpenHudWindows()
        {
            CloseAll();
            
            OpenWindow(WindowTypeId.Input);
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

        public void FillList(UI.Window window) =>
            _windows.Add(window);
        
        public void FillList(IReadOnlyList<UI.Window> windows)
        {
            foreach (var window in windows)
            {
                _windows.Add(window);
            }
        }

    }
}
      
