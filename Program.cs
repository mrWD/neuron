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
        /// Main method that implements a simple neural network training algorithm.
        ///
        /// Training Process:
        /// 1. Initialize weights (w1-w8) with random values
        /// 2. Run training loop for 500 iterations
        /// 3. For each iteration:
        ///    - Test the neural network with input combinations
        ///    - Calculate output using forward propagation (sigmoid activation)
        ///    - Compare output with expected result
        ///    - Calculate error and update weights using backpropagation
        ///    - Track successful predictions
        ///
        /// Neural Network Architecture:
        /// - Input layer: 3 neurons (holiday, badWeather, company)
        /// - Hidden layer: 2 neurons with sigmoid activation
        /// - Output layer: 1 neuron with sigmoid activation
        /// - Learning rate (smoothing): 0.1
        ///
        /// The network learns to predict whether to go to the dacha (cottage)
        /// based on three input conditions.
        /// </summary>
        static void Main(string[] args)
        {
            long step = 0;
            long doneCount = 0;
            int done = 0;

            double w1 = -0.4;
            double w2 = 0.5;
            double w3 = 0.6;
            double w4 = -0.5;
            double w5 = 0.4;
            double w6 = -0.5;
            double w7 = 0.4;
            double w8 = 0.5;

            for (int i = 0; i < 500; i++)
            {
                step += 1;
                done = 0;

                //if (Play(1, 0, 0, w1, w2, w3, w4, w5, w6, w7, w8, 1) == 1) { done += 1; }
                //if (Play(1, 0, 1, w1, w2, w3, w4, w5, w6, w7, w8, 1) == 1) { done += 1; }
                //if (Play(0, 0, 1, w1, w2, w3, w4, w5, w6, w7, w8, 1) == 1) { done += 1; }
                //if (Play(0, 1, 1, w1, w2, w3, w4, w5, w6, w7, w8, 0) == 0) { done += 1; }

                //if (Play(0, 1, 0, w1, w2, w3, w4, w5, w6, w7, w8, 0) == 0) { done += 1; }
                //if (Play(0, 0, 0, w1, w2, w3, w4, w5, w6, w7, w8, 0) == 0) { done += 1; }
                //if (Play(1, 1, 0, w1, w2, w3, w4, w5, w6, w7, w8, 0) == 0) { done += 1; }
                if (Play(1, 1, 1, w1, w2, w3, w4, w5, w6, w7, w8, 0) == 0) { done += 1; }

                if (done == 1)
                {
                    doneCount += 1;
                    Console.WriteLine("\nDone! Step = " + step + "\nDone_count = " + doneCount + "\nw1 = " + w1 + "\nw2 = " + w2 + "\nw3 = " + w3 + "\nw4 = " +
                    w4 + "\nw5 = " + w5 + "\nw6 = " + w6 + "\nw7 = " + w7 + "\nw8 = " + w8);
                    Console.ReadKey();
                }

                Console.WriteLine("\nStep = " + step + "\nDone_count = " + doneCount + "\nw1 = " + w1 + "\nw2 = " + w2 + "\nw3 = " + w3 + "\nw4 = " +
                w4 + "\nw5 = " + w5 + "\nw6 = " + w6 + "\nw7 = " + w7 + "\nw8 = " + w8);
                Console.ReadKey();
            }

            int Play(int holiday, int badWeather, int company, double ww1, double ww2, double ww3, double ww4, double ww5, double ww6, double ww7, double ww8, double expected)
            {
                double activation1, activation2, activation3;
                double sigmoid1, sigmoid2, sigmoid3;
                double error1, error2, error3;
                double sigmoid_dx, correction;
                double smoothing = 0.1;

                activation1 = holiday * ww1 + badWeather * ww2 + company * ww3;
                sigmoid1 = 1 / (1 + Math.Pow(2.718281, -activation1));

                activation2 = holiday * ww4 + badWeather * ww5 + company * ww6;
                sigmoid2 = 1 / (1 + Math.Pow(2.718281, -activation2));

                activation3 = sigmoid1 * ww7 + sigmoid2 * ww8;
                sigmoid3 =  1 / (1 + Math.Pow(2.718281, -activation3));

                error1 = sigmoid3 - expected;
                sigmoid_dx = sigmoid3 * (1 - sigmoid3);
                correction = error1 * sigmoid_dx;
                w8 = w8 - sigmoid2 * correction * smoothing;
                w7 = w7 - sigmoid1 * correction * smoothing;

                error2 = w8 * correction;
                error3 = w7 * correction;

                sigmoid_dx = sigmoid2 * (1 - sigmoid2);
                correction = error2 * sigmoid_dx;
                w6 = w6 - company * correction * smoothing;
                w5 = w5 - badWeather * correction * smoothing;
                w4 = w4 - holiday * correction * smoothing;

                sigmoid_dx = sigmoid1 * (1 - sigmoid1);
                correction = error3 * sigmoid_dx;
                w3 = w3 - company * correction * smoothing;
                w2 = w2 - badWeather * correction * smoothing;
                w1 = w1 - holiday * correction * smoothing;

                Console.WriteLine("\nSigmoid3 = " + sigmoid3);

                if (sigmoid3 > 0.5) { Console.WriteLine("Edem na dachy :-) "); return 1; } else Console.WriteLine("Ne edem na dachy :-( ");  return 0;
            }

            Console.WriteLine("\nStep = " + step + "\nDone_count = " + doneCount + "\nw1 = " + w1 + "\nw2 = " + w2 + "\nw3 = " + w3 + "\nw4 = " +
            w4 + "\nw5 = " + w5 + "\nw6 = " + w6 + "\nw7 = " + w7 + "\nw8 = " + w8);
            Console.WriteLine("\nThe_End");
            Console.WriteLine("Step = " + step);
            Console.ReadKey();
        }
    }
}
