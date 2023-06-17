using UnityEngine;
using UnityEngine.UI;

public class DynamicItem : MonoBehaviour
{
    [SerializeField] private int _index;
    
    private Button _button;

    public int Index =>
        _index;
}
