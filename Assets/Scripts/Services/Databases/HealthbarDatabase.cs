using System.Collections.Generic;
using UI.Health;

namespace Services.Databases
{
    public class HealthbarDatabase
    {
        public static List<HealthView> Values = new List<HealthView>();
        
        public static void Add(HealthView healthView) =>
            Values.Add(healthView);
    }
}