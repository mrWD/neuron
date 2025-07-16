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
        /// Main method that implements a simple perceptron training algorithm.
        ///
        /// Training Process:
        /// 1. The perceptron has 3 inputs: holiday, badWeather, and company
        /// 2. Each input has a corresponding weight (w1, w2, w3)
        /// 3. The activation function calculates: holiday*w1 + badWeather*w2 + company*w3
        /// 4. If activation >= 0.5, output is 1 (play), otherwise 0 (don't play)
        ///
        /// Training Data:
        /// Positive cases (should output 1):
        /// - 100: holiday=1, badWeather=0, company=0 (play on holiday)
        /// - 101: holiday=1, badWeather=0, company=1 (play on holiday with company)
        /// - 001: holiday=0, badWeather=0, company=1 (play with company)
        /// - 011: holiday=0, badWeather=1, company=1 (play with company despite bad weather)
        ///
        /// Negative cases (should output 0):
        /// - 010: holiday=0, badWeather=1, company=0 (don't play in bad weather alone)
        /// - 000: holiday=0, badWeather=0, company=0 (don't play when nothing special)
        /// - 110: holiday=1, badWeather=1, company=0 (don't play on holiday in bad weather)
        /// - 111: holiday=1, badWeather=1, company=1 (special case - don't play despite all positive factors)
        ///
        /// Training Algorithm:
        /// - Brute force approach: systematically test all weight combinations
        /// - Weights range from -1 to 1 in 0.1 increments
        /// - For each combination, test all 8 training cases
        /// - A solution is found when all 8 cases are correctly classified (done == 8)
        /// </summary>
        static void Main(string[] args)
        {
            int Play(int holiday, int badWeather, int company, decimal w1, decimal w2, decimal w3)
            {
                decimal activation;

                activation = holiday * w1 + badWeather * w2 + company * w3;

                Console.WriteLine($"Activation: {activation}");

                if (activation >= 0.5m)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            int step = 1;
            int done = 0;

            for (decimal w3 = -1; w3 <= 1; w3 += 0.1m)
            {
                for (decimal w2 = -1; w2 <= 1; w2 += 0.1m)
                {
                    for (decimal w1 = -1; w1 <= 1; w1 += 0.1m)
                    {
                        done = 0;

                        Console.WriteLine($"\nStep: {step},\nw1: {w1},\nw2: {w2},\nw3: {w3}\n");

                        if (Play(1, 0, 0, w1, w2, w3) == 1) { done += 1; } // 100 +
                        if (Play(1, 0, 1, w1, w2, w3) == 1) { done += 1; } // 101 +
                        if (Play(0, 0, 1, w1, w2, w3) == 1) { done += 1; } // 001 +
                        if (Play(0, 1, 1, w1, w2, w3) == 1) { done += 1; } // 011 +

                        if (Play(0, 1, 0, w1, w2, w3) == 0) { done += 1; } // 010 -
                        if (Play(0, 0, 0, w1, w2, w3) == 0) { done += 1; } // 000 -
                        if (Play(1, 1, 0, w1, w2, w3) == 0) { done += 1; } // 110 -
                        if (Play(1, 1, 1, w1, w2, w3) == 0) { done += 1; } // 111 - (Special case that makes the training fail)

                        if (done == 8) { Console.ReadKey(); }

                        step += 1;
                    }
                }
            }

            Console.WriteLine($"Done: {done}");
            Console.ReadKey();
        }
    }
}
