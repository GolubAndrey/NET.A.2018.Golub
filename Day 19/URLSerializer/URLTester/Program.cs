using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLSerializer;
using Ninject;

namespace URLTester
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new ConfigModule());
            Process<string, URL> process = kernel.Get<Process<string, URL>>();
            process.Start(@"E:\EPAM\NET.A.2018.Golub\Day 19\URLSerializer\xml.xml");
            Console.WriteLine("!");
            Console.ReadLine();
        }
    }
}
