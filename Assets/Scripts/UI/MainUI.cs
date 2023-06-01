using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class MainUI : MonoBehaviour
    { 
        [field: SerializeField] public BulletQuantityMediator BulletQuantityMediator { get; private set; }
    }
}