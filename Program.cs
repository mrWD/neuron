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
        /// Neural Network Training Program
        ///
        /// This program implements a simple 3-layer neural network to learn a decision function
        /// for whether to play outside based on three inputs: holiday, bad weather, and company.
        ///
        /// Network Architecture:
        /// - Input layer: 3 neurons (holiday, badWeather, company)
        /// - Hidden layer: 2 neurons with sigmoid activation
        /// - Output layer: 1 neuron with threshold activation (0.5)
        ///
        /// Training Process:
        /// 1. Brute force search through weight combinations (w1-w8)
        /// 2. For each weight combination, test against 7 training examples
        /// 3. Positive examples (should output 1): 100, 101, 001, 011
        /// 4. Negative examples (should output 0): 010, 000, 110
        /// 5. A solution is found when all 7 examples are correctly classified
        ///
        /// The network learns to play outside when:
        /// - It's a holiday OR
        /// - There's company (regardless of weather)
        /// - But NOT when there's bad weather without holiday or company
        /// </summary>
        /// <param name="args">Command line arguments (not used)</param>
        static void Main(string[] args)
        {
            int Play(
                int holiday,
                int badWeather,
                int company,
                decimal ww1,
                decimal ww2,
                decimal ww3,
                decimal ww4,
                decimal ww5,
                decimal ww6,
                decimal ww7,
                decimal ww8
            )
            {
                decimal activation1;
                decimal activation2;
                decimal activation3;

                double sigmoid1;
                double sigmoid2;

                activation1 = holiday * ww1 + badWeather * ww2 + company * ww3;
                // if (activation1 >= 0.5m) { a1 = 1; } else { a1 = 0; }
                sigmoid1 = 1 / (1 + Math.Pow(2.718281, (double)-activation1));

                activation2 = holiday * ww4 + badWeather * ww5 + company * ww6;
                // if (activation2 >= 0.5m) { a2 = 1; } else { a2 = 0; }
                sigmoid2 = 1 / (1 + Math.Pow(2.718281, (double)-activation2));

                activation3 = (decimal)sigmoid1 * ww7 + (decimal)sigmoid2 * ww8;

                if (activation3 >= 0.5m) { return 1; } else return 0;
            }

            long step = 1;
            long a = 0;
            long donecount = 0;
            int done = 0;

            decimal w8 = 0.5m; // Values from the last lesson
            decimal w7 = 0.4m; // Values from the last lesson
            decimal w6 = 0.9m; // Values from the last lesson

            for (decimal w5 = -1; w5 <= 1; w5 += 0.1m)
            {
                for (decimal w4 = -1; w4 <= 1; w4 += 0.1m)
                {
                    for (decimal w3 = -1; w3 <= 1; w3 += 0.1m)
                    {
                        for (decimal w2 = -1; w2 <= 1; w2 += 0.1m)
                        {
                            for (decimal w1 = -1; w1 <= 1; w1 += 0.1m)
                            {
                                done = 0;

                                if (Play(1, 0, 0, w1, w2, w3, w4, w5, w6, w7, w8) == 1) { done += 1; } // 100 +
                                if (Play(1, 0, 1, w1, w2, w3, w4, w5, w6, w7, w8) == 1) { done += 1; } // 101 +
                                if (Play(0, 0, 1, w1, w2, w3, w4, w5, w6, w7, w8) == 1) { done += 1; } // 001 +
                                if (Play(0, 1, 1, w1, w2, w3, w4, w5, w6, w7, w8) == 1) { done += 1; } // 011 +

                                if (Play(0, 1, 0, w1, w2, w3, w4, w5, w6, w7, w8) == 0) { done += 1; } // 010 -
                                if (Play(0, 0, 0, w1, w2, w3, w4, w5, w6, w7, w8) == 0) { done += 1; } // 000 -
                                if (Play(1, 1, 0, w1, w2, w3, w4, w5, w6, w7, w8) == 0) { done += 1; } // 110 -
                                // if (Play(1, 1, 1, w1, w2, w3, w4, w5, w6, w7, w8) == 0) { done += 1; } // 111 - (Special case that makes the training fail)

                                if (done == 7)
                                {
                                    donecount += 1;
                                    Console.WriteLine($"\nDone! Step: {step},\nDonecount: {donecount}\nw1: {w1},\nw2: {w2},\nw3: {w3},\nw4: {w4},\nw5: {w5},\nw6: {w6},\nw7: {w7},\nw8: {w8}\n");
                                }

                                if (a == 1_000_000)
                                {
                                    Console.WriteLine($"\nStep: {step},\nDonecount: {donecount}\nw1: {w1},\nw2: {w2},\nw3: {w3},\nw4: {w4},\nw5: {w5},\nw6: {w6},\nw7: {w7},\nw8: {w8}\n");
                                    a = 0;
                                }

                                a += 1;
                                step += 1;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("The_End");
            Console.WriteLine("Step = " + step);
            Console.ReadKey();
        }
    }
}
