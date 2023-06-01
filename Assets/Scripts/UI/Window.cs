using System;
using System.Collections;
using System.Collections.Generic;
using Extensions.GameObjectExtension;
using Services.Window;
using UnityEngine;
using UnityEngine.Serialization;

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
        this.enabled = false;
    }
    
    public void Open()
    {
        this.enabled = true;
    }
}
}