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
        /// Neural Network Training for Decision Making
        ///
        /// This program implements a simple 3-layer neural network to learn a decision-making pattern
        /// based on three input factors: holiday, bad weather, and company.
        ///
        /// Network Architecture:
        /// - Input Layer: 3 neurons (holiday, badWeather, company)
        /// - Hidden Layer: 2 neurons with activation threshold of 0.5
        /// - Output Layer: 1 neuron (final decision: play or not play)
        ///
        /// Training Data:
        /// Positive cases (should play):
        /// - (1,0,0): Holiday but no bad weather, no company
        /// - (1,0,1): Holiday, no bad weather, with company
        /// - (0,0,1): No holiday, no bad weather, with company
        /// - (0,1,1): No holiday, bad weather, with company
        ///
        /// Negative cases (should not play):
        /// - (0,1,0): No holiday, bad weather, no company
        /// - (0,0,0): No holiday, no bad weather, no company
        /// - (1,1,0): Holiday, bad weather, no company
        /// - (1,1,1): Holiday, bad weather, with company
        ///
        /// Training Process:
        /// 1. Fixed weights w1, w2, w3 are used for the first layer connections
        /// 2. Brute force optimization searches for optimal weights w4-w8
        /// 3. Each weight combination is tested against all 8 training cases
        /// 4. A solution is found when all 8 cases produce correct outputs
        /// 5. The search continues through all possible weight combinations
        ///
        /// The goal is to find weight values that correctly classify all training examples,
        /// demonstrating the network's ability to learn the underlying decision pattern.
        /// </summary>
        static void Main(string[] args)
        {
            int Play(
                int holiday,
                int badWeather,
                int company,
                decimal ww1,
                decimal ww2,
                decimal ww3,
                decimal w4,
                decimal w5,
                decimal w6,
                decimal w7,
                decimal w8
            )
            {
                decimal activation1;
                decimal activation2;
                decimal activation3;

                int a1 = 0;
                int a2 = 0;

                activation1 = holiday * ww1 + badWeather * ww2 + company * ww3;
                if (activation1 >= 0.5m) { a1 = 1; } else { a1 = 0; }

                activation2 = holiday * w4 + badWeather * w5 + company * w6;
                if (activation2 >= 0.5m) { a2 = 1; } else { a2 = 0; }

                activation3 = a1 * w7 + a2 * w8;

                if (activation3 >= 0.5m) { return 1; } else return 0;
            }

            long step = 1;
            long donecount = 0;
            int done = 0;
            decimal w1 = 0.5m; // Values from the last lesson
            decimal w2 = -0.1m; // Values from the last lesson
            decimal w3 = 0.6m; // Values from the last lesson

            for (decimal w8 = -1; w8 <= 1; w8 += 0.1m)
            {
                for (decimal w7 = -1; w7 <= 1; w7 += 0.1m)
                {
                    for (decimal w6 = -1; w6 <= 1; w6 += 0.1m)
                    {
                        for (decimal w5 = -1; w5 <= 1; w5 += 0.1m)
                        {
                            for (decimal w4 = -1; w4 <= 1; w4 += 0.1m)
                            {
                                done = 0;

                                if (Play(1, 0, 0, w1, w2, w3, w4, w5, w6, w7, w8) == 1) { done += 1; } // 100 +
                                if (Play(1, 0, 1, w1, w2, w3, w4, w5, w6, w7, w8) == 1) { done += 1; } // 101 +
                                if (Play(0, 0, 1, w1, w2, w3, w4, w5, w6, w7, w8) == 1) { done += 1; } // 001 +
                                if (Play(0, 1, 1, w1, w2, w3, w4, w5, w6, w7, w8) == 1) { done += 1; } // 011 +

                                if (Play(0, 1, 0, w1, w2, w3, w4, w5, w6, w7, w8) == 0) { done += 1; } // 010 -
                                if (Play(0, 0, 0, w1, w2, w3, w4, w5, w6, w7, w8) == 0) { done += 1; } // 000 -
                                if (Play(1, 1, 0, w1, w2, w3, w4, w5, w6, w7, w8) == 0) { done += 1; } // 110 -
                                if (Play(1, 1, 1, w1, w2, w3, w4, w5, w6, w7, w8) == 0) { done += 1; } // 111 - (Special case that makes the training fail)

                                if (done == 8) {
                                    donecount += 1;
                                    Console.WriteLine($"\nDone! Step: {step},\nDonecount: {donecount}\nw1: {w1},\nw2: {w2},\nw3: {w3},\nw4: {w4},\nw5: {w5},\nw6: {w6},\nw7: {w7},\nw8: {w8}\n");
                                }

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
