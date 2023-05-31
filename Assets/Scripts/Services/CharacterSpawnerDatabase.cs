using System.Collections.Generic;

namespace Services
{
    public class CharacterSpawnerDatabase
    {
        public static List<CharacterSpawner> Values = new List<CharacterSpawner>();
        
        public static CharacterSpawner Get(SpawnObjectTypeId spawnObjectType)
        {
            for (int i = 0; i < Values.Count; i++)
            {
                if (Values[i].SpawnObjectTypeId == spawnObjectType)
                    return Values[i];
            }

            return null;
        }

        public static void Add(CharacterSpawner characterSpawner) =>
            Values.Add(characterSpawner);
    }
}