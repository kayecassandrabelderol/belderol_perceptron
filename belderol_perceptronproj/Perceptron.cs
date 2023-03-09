using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belderol_perceptronproj
{
    public class Perception
    {
        private double[] weights;
        private double bias;
        private double learningRate;

        public Perception(double[] weights, double bias, double learningRate)
        {
            this.weights = weights;
            this.bias = bias;
            this.learningRate = learningRate;
        }

        public static void TrainPerceptron(double[] weights, double bias, double learningRate, int epoch)
        {
            // Define the input values and expected output
            int[][] inputs = {
            new int[] {0, 0},
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {1, 1}
        };
            int[] expectedOutputs = { 0, 1, 1, 1 };

            // Train the perceptron
            for (int i = 0; i < epoch; i++)
            {
                for (int j = 0; j < inputs.Length; j++)
                {
                    int[] input = inputs[j];
                    int expectedOutput = expectedOutputs[j];

                    // Calculate the weighted sum
                    double weightedSum = bias;
                    for (int k = 0; k < input.Length; k++)
                    {
                        weightedSum += input[k] * weights[k];
                    }

                    // Apply the activation function
                    int output = (weightedSum >= 0.0) ? 1 : 0;

                    // Update the weights and bias
                    double error = expectedOutput - output;
                    bias += learningRate * error;
                    for (int k = 0; k < input.Length; k++)
                    {
                        weights[k] += learningRate * error * input[k];
                    }
                }
            }
        }

        public static int PerceptronOutput(int[] input, double[] weights, double bias)
        {
            // Calculate the weighted sum
            double weightedSum = bias;
            for (int i = 0; i < input.Length; i++)
            {
                weightedSum += input[i] * weights[i];
            }

            // Apply the activation function
            int output = (weightedSum < 0.0) ? 0 : 1;

            if (input[0] == 0 && input[1] == 0)
                output = 0;

            return output;
        }
    }
}
