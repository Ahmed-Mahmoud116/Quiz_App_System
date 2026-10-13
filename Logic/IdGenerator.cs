using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App_System.Logic
{
    internal static class IdGenerator
    {
        private static Random _random = new Random();
        private static List<int> usedIds = new List<int>();
        public static int GenerateID()
        {
            int id;
            do
                id = _random.Next(1, 10001);
            while(usedIds.Contains(id));
            usedIds.Add(id);
            return id;
        }
    }
}
