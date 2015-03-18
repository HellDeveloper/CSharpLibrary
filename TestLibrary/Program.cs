using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Core;
using Utility.Collections;
using Utility.Data;
using System.Data;

namespace TestLibrary
{
    class Program
    {
        public static void Main(string[] args)
        {
            ParameterDirection direction = ParameterDirection.Input;
            if (Enum.TryParse("InputOutpu", true, out direction))
            {
            }
            Console.WriteLine(direction);
            Console.WriteLine((int)ParameterDirection.Input);

            Console.WriteLine(typeof(ParameterDirection).BaseType);
            Console.ReadKey(true);
        }
    }
}
