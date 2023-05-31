using System;
using UnityEngine;
using UnityEngine.UI;

public class DynamicItem : MonoBehaviour
{
    [SerializeField] private int _index;
    
    private Button _button;

    public Button Button =>
        _button;
    
    public int Index =>
        _index;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy(gameObject,0.1f);
    }
}
