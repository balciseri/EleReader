using System;
using System.Diagnostics;

namespace EleReader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
#if DEBUG
                args = new[] {  @".\elements.ele" };
#endif

                if (args != null)
                {
                    string eleFilePath;

                    eleFilePath = args[0];

                    new App(eleFilePath);

                    if (Debugger.IsAttached)
                    {
                        Console.WriteLine("Press any key to continue . . .");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}


