using System.Collections.Generic;
using Gameplay.Weapon;

namespace Services.Databases
{
    public class WeaponDatabase
    {
        public static List<Weapon> Values = new List<Weapon>();
        
        public static Weapon Get(ObjectTypeId objectTypeId)
        {
            for (int i = 0; i < Values.Count; i++)
            {
                if (Values[i].ObjectTypeId == objectTypeId)
                    return Values[i];
            }

            return null;
        }

        public static void Add(Weapon weapon) =>
            Values.Add(weapon);
    }
}