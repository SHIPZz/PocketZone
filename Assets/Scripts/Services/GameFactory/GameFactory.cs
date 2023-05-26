using UnityEngine;

namespace Services.GameFactory
{
    public class GameFactory
    {
        public GameObject CreateObject(string name)
        {
            GameObject prefab = Resources.Load<GameObject>(name);

            return Object.Instantiate(prefab);
        }
    }
}
