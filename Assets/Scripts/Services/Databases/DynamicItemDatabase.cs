using System.Collections.Generic;

namespace Services.Databases
{
    public class DynamicItemDatabase
    {
        public static List<DynamicItem> Values = new List<DynamicItem>();
        
        public static DynamicItem Get(int index)
        {
            for (int i = 0; i < Values.Count; i++)
            {
                if (Values[i].Index == index)
                    return Values[i];
            }

            return null;
        }

        public static void Add(DynamicItem dynamicItem) =>
            Values.Add(dynamicItem);
    }
}