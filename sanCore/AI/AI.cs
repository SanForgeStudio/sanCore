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

using System;

namespace sanCore.AI
// Implement the logic to process the question and generate a response.
// You can use various algorithms or APIs to perform natural language processing.
// Return the AI's response.
// The project already contains the OpenAI dependancies only it would need the logic for it.
{
    public class AI
    {

        public string AnswerQuestion(string question)
        {
            question = question.ToLower();

            if (question.Contains("hello") || question.Contains("hi"))
            {
                return "Hello there!";
            }
            else if (question.Contains("how are you"))
            {
                return "I'm just a computer program, but I'm functioning well!";
            }

            else if (question.Contains("who created you") || question.Contains("who made you") || question.Contains("who made you?") || question.Contains("who created you?"))
            {
                return "I was created by the talented team of developers at SanDigitals.";
            }
            else if (question.Contains("what is your purpose") || question.Contains("why were you made") || question.Contains("what do you do"))
            {
                return "My purpose is to assist and provide information to users. I'm here to help you with various tasks and answer your questions.";
            }
            else if (question.Contains("how does AI work") || question.Contains("what is artificial intelligence") || question.Contains("explain AI"))
            {
                return "Artificial Intelligence (AI) is the simulation of human intelligence processes by machines. It involves creating algorithms that allow computers to learn from and make decisions based on data. Sadly i do not possess self learning skills.";
            }
            else if (question.Contains("what can you do") || question.Contains("tell me your capabilities") || question.Contains("what are your features"))
            {
                return "I can answer simple questions, provide information, perform basic calculations, help you navigate the system, and more. Feel free to ask me anything!";
            }
            else if (question.Contains("how can I contact support") || question.Contains("need assistance") || question.Contains("help me"))
            {
                return "If you need assistance, you can reach out to our support team at our website www.sandigital.org";
            }


            else if (question.Contains("tell me a joke") || question.Contains("make me laugh") || question.Contains("say something funny"))
            {
                Random random = new Random();
                int jokeNumber = random.Next(1, 4); // Choose a random joke

                switch (jokeNumber)
                {
                    case 1:
                        return "Why don't programmers like nature? It has too many bugs.";
                    case 2:
                        return "Why did the scarecrow win an award? Because he was outstanding in his field!";
                    case 3:
                        return "Parallel lines have so much in common. It's a shame they'll never meet.";
                    case 4:
                        return "Why do we never tell secrets on a farm? Because the potatoes have eyes and the corn has ears!";
                    default:
                        return "Why did the computer go to therapy? Because it had too many bytes of emotional baggage!";
                }
            }


            else
            {
                return "I'm sorry, I don't have a specific answer for that question.";
            }
        }
    }
}
