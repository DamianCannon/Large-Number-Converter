using System;

namespace LargeNumberConverter
{
    class Program
    {
        static void Main()
        {
            var converter = new NumberConverter();

            Console.WriteLine("Please enter a numeric value less than 999,999,999 to convert (Q to Quit):");
            string input = Console.ReadLine();
            while (!input.ToLower().Equals("q"))
            {
                var inputValue = 0;
                if (int.TryParse(input, out inputValue) && inputValue < 1000000000)
                {
                    Console.WriteLine("Converts to: {0}", converter.Convert(inputValue));
                }
                else
                {
                    Console.WriteLine("Please enter an allowed value");
                }
                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
    }
}
