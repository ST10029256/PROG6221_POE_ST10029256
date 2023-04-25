using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10029256
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker_class worker = new Worker_class();
            worker.StoreDataInArray();
            worker.Scaling();
            worker.Display();

        }
    }
}
