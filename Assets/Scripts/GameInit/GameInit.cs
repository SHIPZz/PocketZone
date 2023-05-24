using System;
using Services.DependencyContainer;
using UnityEngine;

namespace GameInit
{
    public class GameInit : MonoBehaviour
    {
        private  DependencyRegister _dependencyRegister;

        private void Awake()
        {
            _dependencyRegister = new DependencyRegister();
        }

        private void Update()
        {
            _dependencyRegister.Update();
        }
    }
}