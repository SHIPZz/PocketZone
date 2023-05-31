using UnityEngine;

namespace Services.Window
{
    public abstract class WindowBase : MonoBehaviour
    {
        [SerializeField] private WindowTypeId _windowTypeId;
        
        public abstract void OnOpen();

        public abstract void OnClose();
    }
}