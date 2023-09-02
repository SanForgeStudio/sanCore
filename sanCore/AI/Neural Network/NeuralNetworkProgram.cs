/*
 * Copyright 2023 sanDigitals
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <https://www.gnu.org/licenses/>.
 *
 */

namespace sanCore.NeuralNetwork
{
    /// <summary>
    /// NeuralNetwork executor.
    /// </summary>
    public class NeuralNetworkProgram
    {
        /// <summary>
        /// NeuralNetwork.
        /// </summary>
        public NeuralNetwork neuralNetwork;

        /// <summary>
        /// Execution memory like input/output.
        /// </summary>
        public NeuralNetworkContext context = new NeuralNetworkContext();

        /// <summary>
        /// Flag indicating new input data.
        /// </summary>
        public bool hasInput;
        /// <summary>
        /// Flag indicating new output data.
        /// </summary>
        public bool hasOutput;


        public int state = -1, total = -1;
        public float loss = 0.0f;

        /// <summary>
        /// Create new NeuralNetworkProgram for NeuralNetwork.
        /// </summary>
        /// <param name="nn"></param>
        public NeuralNetworkProgram(NeuralNetwork nn)
        {
            neuralNetwork = nn;

            context.Setup(nn);

            hasInput = false;
            hasOutput = false;
        }

        /// <summary>
        /// Execute NeuralNetwork program.
        /// </summary>
        public void Execute()
        {
            neuralNetwork.Execute(context);
            hasInput = false;
            hasOutput = true;
        }
    }
}
