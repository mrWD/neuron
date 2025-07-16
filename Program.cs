using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuron
{
    class Program
    {
        /// <summary>
        /// This method attempts to "train" a simple linear model to convert Celsius to Fahrenheit.
        /// It does so by brute-forcing all possible combinations of weights (w1 and w2) in the equation:
        ///     output = celsius * w1 + input2 * w2
        /// The goal is to find values of w1 and w2 such that the output matches the expected Fahrenheit value.
        /// For each combination, it prints the step, weights, and output. If the output matches the expected value, it pauses for a key press.
        /// This is a naive approach and not a true machine learning training loop, but demonstrates the concept of searching for optimal parameters.
        /// </summary>
        static void Main(string[] args)
        {
            decimal celsius = 100;
            decimal expectedFahrenheit = 212;
            decimal input2 = 1;
            decimal output = 1;
            int step = 1;



            for (decimal w2 = 0.1m; w2 < 100; w2 += 0.1m)
            {
                for (decimal w1 = 0.1m; w1 < 100; w1 += 0.1m)
                {
                    output = celsius * w1 + input2 * w2;
                    Console.WriteLine($"\nStep: {step},\nw1: {w1},\nw2: {w2},\nOutput: {output}\n");
                    // Console.ReadKey();

                    if (output == expectedFahrenheit)
                    {
                        // Step: 19002,
                        // w1: 2.1,
                        // w2: 2.0,
                        // Output: 212.0
                        // ...
                        // Step: 118901,
                        // w1: 2.0,
                        // w2: 12.0,
                        // Output: 212.0
                        // ...
                        // Step: 318699,
                        // w1: 1.8,
                        // w2: 32.0,
                        // Output: 212.0
                        Console.ReadKey();
                    }

                    step += 1;
                }
            }

            Console.ReadKey();
        }
    }
}
