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
        gameObject.SetActive(false);
    }
    
    public void Open()
    {
        gameObject.SetActive(true);
    }
}
}