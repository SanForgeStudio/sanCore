using System;
using sanCore.Commands;

namespace sanCore
{
    public static class AICommand
    {
        private static bool isAIActivated = false;

        public static void ActivateAI()
        {
            if (!isAIActivated)
            {
                AI.Brain ai = new AI.Brain();
                Console.WriteLine("AI activated. You can ask me any question. Type 'exit' to exit.");
                TalkToAI(ai);

                Console.WriteLine("AI deactivated.");
                isAIActivated = false;
            }
            else
            {
                Console.WriteLine("AI is already activated.");
            }
        }




        private static void TalkToAI(AI.Brain ai)
        {
            string question;
            do
            {
                Console.Write("You: ");
                question = Console.ReadLine();
                if (question.ToLower() != "exit")
                {
                    string answer = ai.AnswerQuestion(question);
                    Console.WriteLine("AI System: " + answer);
                }
            } while (question.ToLower() != "exit");
        }
    }
}