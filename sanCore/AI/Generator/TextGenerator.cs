using System;
using System.IO;
using System.Collections.Generic;
using sanCore.NeuralNetwork;
using sanCore.AI;

namespace MessingAround
{
    class TextGenerator
    {
        static void Main(string[] args)
        {



            // Read example text
            string exampleTxt = File.ReadAllText("example.txt");

            // Encode in one-hot encoding, each letter is assigned a unique neuron.
            List<char> dict = null;
            float[][] data = Utils.EncodeStringOneHot(exampleTxt, out dict);

            // Create neural network
            int hlen = exampleTxt.Length / 4;
            NeuralNetwork neuralNetwork = new NeuralNetwork(
                new NeuralNetworkLayer(dict.Count, false, null),
                new NeuralNetworkLayer[] {
                    new NeuralNetworkLayer(hlen, true, Utils.Rectifier_ActivationFunction),
                },
                new NeuralNetworkLayer(dict.Count, false, Utils.Rectifier_ActivationFunction)
            );
            neuralNetwork.RandomizeWeightsAndBiases(0.0f, 0.0f, 0.0f, 0.5f / hlen);

            // Convert into training data for neural network
            float[][] inputDat = new float[data.Length - 1][];
            float[][] targetDat = new float[data.Length - 1][];
            for (int i = 0; i < data.Length - 1; i++)
            {
                inputDat[i] = data[i];
                targetDat[i] = data[i + 1];
            }

            // Train neural network
            NeuralNetworkTrainer trainer = new NeuralNetworkTrainer(neuralNetwork, inputDat, targetDat, 2, NeuralNetworkTrainer.LOSS_TYPE_AVERAGE);
            trainer.learningRate = 0.04f;
            trainer.desiredLoss = 0.0f;
            trainer.lossSmoothing = 0.0f;
            trainer.StartInit();

            long lastTime = 0, nowTime;
            while (true)
            {
                trainer.Learn();
                nowTime = System.DateTime.Now.Ticks / 10000;
                if (nowTime - lastTime > 10000)
                {
                    string generatedText = GenerateTextFromNeuralNetwork(neuralNetwork, dict);
                    Console.WriteLine("Generated Text: " + generatedText);

                    Brain ai = new Brain();
                    string aiResponse = ai.AnswerQuestion(generatedText);
                    Console.WriteLine("AI Response: " + aiResponse);

                    lastTime = nowTime;
                }
            }
        }

        static string GenerateTextFromNeuralNetwork(NeuralNetwork neuralNetwork, List<char> dict)
        {
            // Your existing code for generating text goes here
            // ... (rest of your text generation code)
            string generatedText = ""; // Initialize the generated text variable
            // Return the generated text
            return generatedText;
        }
    }
}
