
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    public class QuickSortDriver
    {
        public static void Main(string[] args)
        {
            QuickSorter<int> q = new();
            List<int> nums = new List<int> { 1, 3, 5};
            q.Sort(nums);
        }
    }
}
