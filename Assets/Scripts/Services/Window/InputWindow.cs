using Services.DependencyContainer;
using UnityEngine;
using UnityEngine.UI;

namespace Services.Window
{
    public class InputWindow : UI.Window
    {
        [field: SerializeField] public Button ShootButton { get; private set; }

        private void Awake()
        {
            WindowDatabase.Add(this);
        }
        

    }
}