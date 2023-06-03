using Services;
using UnityEngine;

public class SpawnersCollection : MonoBehaviour
{
    public CharacterSpawner[] AllSpawners { get; private set; }

    private void Awake()
    {
        AllSpawners = GetComponentsInChildren<CharacterSpawner>();
    }
}
