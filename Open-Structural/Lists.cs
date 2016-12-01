using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;

namespace Utilities
{
    public static class Lists
    {
        [MultiReturn(new string[] { "Cleaned", "Indices" })]
        public static Dictionary<string, object> RemoveNulls(List<object> Data)
        {
            List<object> list1 = Data;
            List<int> list2 = new List<int>();
            for (int index = 0; index < list1.Count; ++index)
            {
                if (list1[index] == null)
                    list2.Add(index);
            }
            list1.RemoveAll((Predicate<object>)(item => item == null));
            return new Dictionary<string, object>()
      {
        {
          "Cleaned",
          (object) list1
        },
        {
          "Indices",
          (object) list2
        }
      };
        }

        public static object ReplaceNulls(object Data, object ReplaceWith)
        {
            return Data != null ? Data : ReplaceWith;
        }

        [MultiReturn(new string[] { "Randomized", "Indices" })]
        public static Dictionary<string, object> RandomizeOrder(List<object> Data, int Seed)
        {
            Random random = new Random(Seed);
            List<double> list1 = new List<double>();
            List<int> list2 = new List<int>();
            int num1 = 0;
            foreach (object obj in Data)
            {
                double num2 = random.NextDouble();
                list1.Add(num2);
                list2.Add(num1);
                ++num1;
            }
            int[] items1 = list2.ToArray();
            object[] items2 = Data.ToArray();
            Array.Sort<double, object>(list1.ToArray(), items2);
            Array.Sort<double, int>(list1.ToArray(), items1);
            return new Dictionary<string, object>()
      {
        {
          "Randomized",
          (object) items2
        },
        {
          "Indices",
          (object) items1
        }
      };
        }
    }
}

