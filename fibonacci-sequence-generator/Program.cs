using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace fibonacci_sequence_generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Sequence length: ");

            while(true) {
                try {
                    int numTerms = Convert.ToInt32(Console.ReadLine());
                    var fibSeq = new FibonacciSequence(numTerms);
                    Console.WriteLine(fibSeq.ToString());
                    break;
                }
                catch (ArgumentOutOfRangeException e) {
                    Console.WriteLine($"({e.ParamName}) Try an range between 1 and 100,000");
                    continue;
                }
            }

            Console.ReadKey();
        }
    }
    
    class FibonacciSequence
    {
        private List<BigInteger> sequence = new List<BigInteger> { 0, 1 };

        public FibonacciSequence(int numTerms)
        {
            // Terms should range between 0 and 100000
            if (!ValidateConstraints(numTerms))
                throw new ArgumentOutOfRangeException("n terms out of range");

            GenerateSequence(numTerms);
        }

        private bool ValidateConstraints(int numTerms)
        {
            if (numTerms < 0 || numTerms > 100000) 
                return false;
       
            return true;
        }

        private void GenerateSequence(int numTerms)
        {
            if (numTerms == 1)
                sequence.RemoveAt(1);
            else if (numTerms == 0)
                sequence.Clear();
            else {
                for (int i = numTerms; i > 2; i--)
                {
                    BigInteger lastTerm = sequence[sequence.Count - 1];
                    BigInteger secondLastTerm = sequence[sequence.Count - 2];

                    sequence.Add(lastTerm + secondLastTerm);
                }
            }
        }

        public override string ToString()
        {
            string fibonacciString = "";

            for (int i = 0; i < sequence.Count; i++) {
                fibonacciString += ($"{sequence[i]}");

                if (i != (sequence.Count - 1))
                    fibonacciString += ",";
            }

            return fibonacciString;
        }
    }
}
