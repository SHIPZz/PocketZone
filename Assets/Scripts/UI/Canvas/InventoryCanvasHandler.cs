using Extensions.GameObjectExtension;
using UnityEngine;

public class InventoryCanvasHandler : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private Canvas _canvas;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvas = GetComponent<Canvas>();
    }

    public void Close()
    {
        _canvas.gameObject.ChangeScale(0,0);
        _canvas.enabled = false;
    }
    
    public void Open()
    {
        _canvas.gameObject.ChangeScale(1,1);
        _canvas.enabled = true;
    }
}
