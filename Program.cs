using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuron
{
    public class Neuron
    {
        public decimal weight = 0.5m; // Example weight for a neuron
        public decimal Error;
        public decimal Smooth = 0.1m; // Example smoothing factor

        public decimal Calculate(decimal input)
        {
            // Simple activation function
            return input * weight;
        }

        public decimal Reverse(decimal input)
        {
            // Reverse the activation function
            return input / weight;
        }

        public void Train(decimal input, decimal expectedValue)
        {
            var realValue = input * weight; // 50
            Error = expectedValue - realValue; // -10
            var correction = (Error / realValue) * Smooth; // -0.2
            weight += correction; // 0.48
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            decimal cm = 100;
            decimal inch = 39.370m;

            Neuron neuron = new Neuron();

            int i = 0;

            do
            {
                i++;
                neuron.Train(cm, inch);
                Console.WriteLine($"Step: {i}\nError: {neuron.Error}");
                Console.WriteLine($"Weight: {neuron.weight}\n");
            } while (neuron.Error > neuron.Smooth || neuron.Error < -neuron.Smooth);

            Console.WriteLine($"Done! Weight: {neuron.weight}");

            Console.WriteLine($"{neuron.Calculate(100)} inches for {100} cm");
            Console.WriteLine($"{neuron.Calculate(300)} inches for {300} cm");
            Console.WriteLine($"{neuron.Reverse(50)} cm for {50} inches");

            Console.ReadLine();
        }
    }
}
