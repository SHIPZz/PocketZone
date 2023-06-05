using DG.Tweening;
using Services.Window;
using UnityEngine;

namespace UI
{
    public  class Window  : MonoBehaviour
{
   [field: SerializeField] public WindowTypeId WindowTypeId { get; private set; }

   private void Awake()
    {
        WindowDatabase.Add(this);
    }

    public void Close()
    {
        gameObject.transform.DOScale(0, 0);
    }
    
    public void Open()
    {
        gameObject.transform.DOScale(1, 0);
    }
}
}