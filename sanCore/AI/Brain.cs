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
using System.Collections.Generic;
using sanCore.NeuralNetwork;
using System.IO; // Add the using directive for file operations
using sanCore.AI;
using sanCore.Commands;
using Sys = Cosmos.System;

namespace sanCore.AI
// Implement the logic to process the question and generate a response.
// You can use various algorithms or APIs to perform natural language processing.
// Return the AI's response.
// The project already contains the OpenAI dependancies only it would need the logic for it.
{
    public class Brain
    {
        public string AnswerQuestion(string question)
        {
            question = question.ToLower();

            if (question.Contains("hello") || question.Contains("hi"))
            {
                return "Hello there! My name is SANAI your offline self learning AI";
            }
            else if (question.Contains("how are you"))
            {
                return "I'm just a computer program, but I'm functioning well!";
            }

            else if (question.Contains("who created you") || question.Contains("who made you") || question.Contains("who made you?") || question.Contains("who created you?"))
            {
                return "I was made by Sander Kerkhoff so he is my maker";
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
            if (question.Contains("difference between stack and heap") || question.Contains("stack vs heap") || question.Contains("stack allocation vs heap allocation"))
            {
                return "Stack is used for static memory allocation, while heap is used for dynamic memory allocation.";
            }

            else if (question.Contains("what is RESTful API") || question.Contains("explain REST API") || question.Contains("what does REST stand for"))
            {
                return "REST stands for Representational State Transfer. It's an architectural style for designing networked applications.";
            }

            else if (question.Contains("how does HTTPS work") || question.Contains("explain SSL/TLS") || question.Contains("secure connection in web"))
            {
                return "HTTPS uses SSL/TLS protocols to establish a secure encrypted connection between a client and a server.";
            }

            else if (question.Contains("difference between abstraction and encapsulation") || question.Contains("abstraction vs encapsulation") || question.Contains("abstraction and encapsulation comparison"))
            {
                return "Abstraction is about hiding unnecessary details, while encapsulation involves bundling data and methods that operate on the data into a single unit.";
            }

            else if (question.Contains("what is a JOIN in SQL") || question.Contains("types of database joins") || question.Contains("SQL query with multiple tables"))
            {
                return "JOIN in SQL combines rows from two or more tables based on a related column between them.";
            }
            if (question.Contains("what is gravity") || question.Contains("explain gravity"))
            {
                return "Gravity is a fundamental force of attraction between objects with mass. It causes objects to be drawn towards each other.";
            }

            else if (question.Contains("who discovered gravity") || question.Contains("who formulated the law of universal gravitation"))
            {
                return "Sir Isaac Newton formulated the law of universal gravitation in 1687, which described how gravity works and its mathematical principles.";
            }

            else if (question.Contains("how does gravity work") || question.Contains("what causes gravitational attraction"))
            {
                return "Gravity is caused by the mass of objects. The more massive an object, the stronger its gravitational pull. It's described by Newton's law of universal gravitation.";
            }

            else if (question.Contains("difference between gravity and gravitation") || question.Contains("gravity vs gravitation"))
            {
                return "Gravity refers to the force of attraction between masses, while gravitation is the natural phenomenon by which physical bodies attract each other with this force.";
            }

            else if (question.Contains("effects of gravity") || question.Contains("how does gravity affect objects"))
            {
                return "Gravity causes objects to fall to the ground, gives weight to objects, and governs the motion of planets, moons, and other celestial bodies.";
            }

            else if (question.Contains("Einstein's theory of general relativity") || question.Contains("what is general relativity"))
            {
                return "Albert Einstein's theory of general relativity introduced a new understanding of gravity. It describes gravity as the curvature of spacetime caused by mass and energy.";
            }

            if (question.Contains("what is history") || question.Contains("define history"))
            {
                return "History is the study of past events, particularly human activities, through the examination of written records, artifacts, and other sources.";
            }

            else if (question.Contains("ancient civilizations") || question.Contains("oldest civilizations in history"))
            {
                return "Some of the oldest civilizations in history include Mesopotamia, Egypt, the Indus Valley Civilization, and ancient China.";
            }

            else if (question.Contains("important historical events") || question.Contains("major turning points in history"))
            {
                return "Events like the Renaissance, the Industrial Revolution, World Wars, and the moon landing are considered major turning points in human history.";
            }

            else if (question.Contains("famous historical figures") || question.Contains("notable people from history"))
            {
                return "Figures like Leonardo da Vinci, Cleopatra, Martin Luther King Jr., and Marie Curie have had a profound impact on history.";
            }

            else if (question.Contains("historical time periods") || question.Contains("epochs in history"))
            {
                return "History is divided into periods like the Ancient, Medieval, Renaissance, Industrial, and Modern eras, each characterized by distinct developments.";
            }

            else if (question.Contains("world-changing inventions") || question.Contains("inventions that shaped history"))
            {
                return "Inventions such as the printing press, steam engine, telephone, and internet have had transformative effects on societies throughout history.";
            }

            if (question.Contains("what is a GUI") || question.Contains("define Graphical User Interface"))
            {
                return "A Graphical User Interface (GUI) is a visual way for users to interact with software using graphical elements such as icons, windows, buttons, and menus.";
            }

            else if (question.Contains("benefits of GUI") || question.Contains("advantages of Graphical User Interface"))
            {
                return "GUIs offer user-friendly interactions, reduced learning curves, efficient data representation, and the ability to provide rich multimedia experiences.";
            }

            else if (question.Contains("elements of GUI") || question.Contains("components of Graphical User Interface"))
            {
                return "Common GUI elements include windows, buttons, text fields, checkboxes, radio buttons, dropdown lists, sliders, and icons.";
            }

            else if (question.Contains("evolution of GUI") || question.Contains("history of Graphical User Interface"))
            {
                return "GUIs have evolved from early systems like Xerox PARC's Alto to modern interfaces found in operating systems like Windows, macOS, and various mobile platforms.";
            }

            else if (question.Contains("GUI design principles") || question.Contains("tips for designing effective GUI"))
            {
                return "GUI design should focus on simplicity, consistency, feedback, responsiveness, and intuitive navigation to enhance user experience.";
            }

            else if (question.Contains("difference between GUI and CLI") || question.Contains("GUI vs Command Line Interface"))
            {
                return "GUI offers visual interactions using icons and menus, while Command Line Interface (CLI) relies on text commands. GUI is more user-friendly, while CLI is powerful for scripting and automation.";
            }
            if (question.Contains("can you make me GUI") || question.Contains("can you create GUI") || question.Contains("can you make GUI"))
            {
                return "ofcourse, i was designed to make a GUI based on your input, please provide your request.";
            }
            if (question.Contains("can you explain machine learning") || question.Contains("explain the concept of machine learning"))
            {
                return "Machine learning is a subset of artificial intelligence that focuses on enabling computers to learn from data and improve their performance on a task over time.";
            }

            else if (question.Contains("what is the internet of things") || question.Contains("explain IoT"))
            {
                return "The Internet of Things (IoT) refers to the network of interconnected physical devices, vehicles, buildings, and other objects that are embedded with sensors, software, and connectivity to exchange data.";
            }

            else if (question.Contains("how does facial recognition work") || question.Contains("explain the process of facial recognition"))
            {
                return "Facial recognition uses AI algorithms to analyze facial features from images or videos. It identifies unique landmarks, patterns, and distances between facial components to match and recognize individuals.";
            }

            else if (question.Contains("what is natural language processing") || question.Contains("explain NLP"))
            {
                return "Natural Language Processing (NLP) involves AI techniques to enable computers to understand, interpret, and generate human language. It's used in tasks like language translation, sentiment analysis, and chatbots.";
            }

            else if (question.Contains("can AI beat humans in games") || question.Contains("how does AI win in games"))
            {
                return "Yes... AI can excel in games by employing techniques like reinforcement learning. It plays games repeatedly, learns from its successes and failures, and optimizes strategies to achieve superhuman performance.";
            }

            else if (question.Contains("how do self-driving cars work") || question.Contains("explain the functioning of autonomous vehicles"))
            {
                return "Self-driving cars use a combination of sensors (such as LiDAR, cameras, and radar), advanced algorithms, and real-time data processing to navigate and make driving decisions without human intervention.";
            }
            if (question.Contains("what is virtual reality") || question.Contains("explain VR"))
            {
                return "Of course! I'm here to help. Virtual Reality, or VR, is a technology that immerses users in a simulated environment. It often involves wearing a headset that tracks your movements. Is there a specific aspect you'd like to know more about?";
            }

            else if (question.Contains("how does blockchain work") || question.Contains("explain blockchain technology"))
            {
                return "Certainly! I'm here to share knowledge. Blockchain is a distributed and secure digital ledger that records transactions across multiple computers. It ensures transparency and tamper resistance. Do you want to dive deeper into its workings?";
            }

            else if (question.Contains("what is deep learning") || question.Contains("explain deep neural networks"))
            {
                return "Absolutely! I'm here to assist you. Deep learning involves complex neural networks with multiple layers. It's used for tasks like image recognition and natural language processing. Would you like more insights into its applications?";
            }

            else if (question.Contains("how do recommendation systems work") || question.Contains("explain the functioning of recommendation algorithms"))
            {
                return "Of course! I'm here to explain. Recommendation systems analyze user behavior to suggest items they might like. They use techniques like collaborative filtering and content-based filtering. Do you want to know about specific types?";
            }

            else if (question.Contains("what is augmented reality") || question.Contains("explain AR"))
            {
                return "Certainly! I'm here to share insights. Augmented Reality, or AR, overlays digital elements onto the real world using devices like smartphones or AR glasses. Would you like examples of AR applications?";
            }

            else if (question.Contains("how does natural selection work") || question.Contains("explain the process of natural selection"))
            {
                return "Of course! I'm here to provide information. Natural selection is a fundamental principle of evolution. It involves the survival and reproduction of organisms with advantageous traits. Is there a specific aspect you'd like to explore?";
            }
            if (question.Contains("explain blockchain to me") || question.Contains("what's the deal with blockchain"))
            {
                return "Sure thing! Blockchain is like a super-secure digital ledger. It records transactions in blocks, and once they're in, it's almost impossible to change anything. Think of it as an unbreakable digital chain.";
            }

            else if (question.Contains("what's the deal with deep learning") || question.Contains("tell me about deep neural networks"))
            {
                return "Deep learning is like training a computer brain with many layers. It's like teaching a dog new tricks, but these tricks involve recognizing images or understanding language!";
            }

            else if (question.Contains("how do recommendation systems do their magic") || question.Contains("how do recommendation algorithms work"))
            {
                return "Recommendation systems are like friendly helpers that suggest things you might like. They look at what you've done before, what others like you are doing, and cook up suggestions based on that.";
            }

            else if (question.Contains("what's the Turing test all about") || question.Contains("explain Turing's test for AI"))
            {
                return "The Turing test is like a quiz to see if a computer can talk like a human. If a judge can't tell whether they're talking to a person or a machine, the machine passes with flying colors!";
            }

            else if (question.Contains("how does encryption keep things safe") || question.Contains("what's the scoop on encryption"))
            {
                return "Encryption is like putting secret messages in a locked box. Only the right key can unlock it. So, when you send sensitive stuff online, it's like sending a locked box no one else can open!";
            }

            else if (question.Contains("what's the story with the Big Bang theory") || question.Contains("tell me about the Big Bang"))
            {
                return "The Big Bang theory is like a grand cosmic explosion. It's the idea that the universe started from a super tiny, hot point and expanded into the vastness we see today. A pretty mind-boggling story!";
            }
            if (question.Contains("tell me about quantum computing") || question.Contains("how does quantum computing work"))
            {
                return "Quantum computing is like harnessing the power of atoms to supercharge computation. It uses quantum bits (qubits) that can exist in multiple states simultaneously, offering the potential for incredibly fast and complex calculations.";
            }

            else if (question.Contains("what is the theory of relativity") || question.Contains("explain Einstein's theory of relativity"))
            {
                return "The theory of relativity, developed by Albert Einstein, includes both the special and general theories. It revolutionized our understanding of space, time, and gravity, showing that they are interconnected in ways we didn't previously realize.";
            }

            else if (question.Contains("how do neural networks learn") || question.Contains("explain neural network training"))
            {
                return "Neural networks learn through a process called training. They adjust their internal parameters based on the difference between their predictions and actual outcomes. This iterative process continues until the network becomes proficient at the task it's designed for.";
            }

            else if (question.Contains("what is climate change") || question.Contains("explain global warming"))
            {
                return "Climate change refers to long-term alterations in Earth's climate patterns. Global warming is a key aspect, caused by the increase in greenhouse gases like carbon dioxide, leading to rising temperatures and various environmental impacts.";
            }

            else if (question.Contains("how does photosynthesis work") || question.Contains("explain the process of photosynthesis"))
            {
                return "Photosynthesis is like the magic trick plants perform with sunlight. They use sunlight, carbon dioxide, and water to produce glucose and oxygen. This process is essential for sustaining life on Earth.";
            }

            else if (question.Contains("what is the Higgs boson") || question.Contains("explain the Higgs boson particle"))
            {
                return "The Higgs boson is often called the 'God particle.' It's a fundamental particle that gives other particles mass. Its discovery at the Large Hadron Collider confirmed a crucial part of the Standard Model of particle physics.";
            }

            else if (question.Contains("how do vaccines work") || question.Contains("explain vaccine mechanism"))
            {
                return "Vaccines are like training for your immune system. They contain weakened or inactive forms of pathogens to stimulate an immune response without causing the disease. This prepares your body to defend against future infections.";
            }

            else if (question.Contains("what is artificial neural network") || question.Contains("explain ANN"))
            {
                return "An Artificial Neural Network (ANN) is a computational model inspired by the human brain. It's composed of interconnected nodes (neurons) that process information. ANNs are used in various applications, including machine learning and pattern recognition.";
            }

            else if (question.Contains("how does 3D printing work") || question.Contains("explain the 3D printing process"))
            {
                return "3D printing is like building something layer by layer with a special printer. It takes a 3D digital model and creates a physical object by adding material one thin layer at a time. It's used in industries from healthcare to aerospace.";
            }

            else if (question.Contains("what is renewable energy") || question.Contains("explain renewable energy sources"))
            {
                return "Renewable energy sources are like the Earth's own power plants. They include solar, wind, hydro, and geothermal energy, which are naturally replenished and have minimal environmental impact compared to fossil fuels.";
            }
            if (question.Contains("what is a programming language") || question.Contains("explain programming languages"))
            {
                return "A programming language is like a communication tool between humans and computers. It consists of rules and syntax for writing instructions that a computer can understand and execute.";
            }

            else if (question.Contains("what is object-oriented programming") || question.Contains("explain OOP"))
            {
                return "Object-Oriented Programming (OOP) is like designing software with building blocks. It organizes code into objects, each with its own data and behavior, to promote modularity, reusability, and easier maintenance.";
            }

            else if (question.Contains("what is a function in programming") || question.Contains("explain functions"))
            {
                return "A function is like a reusable recipe in programming. It's a self-contained block of code that performs a specific task. Functions can take inputs (arguments) and produce outputs (return values).";
            }

            else if (question.Contains("what is version control") || question.Contains("explain version control systems"))
            {
                return "Version control is like a time machine for your code. It tracks changes to files and code over time, allowing multiple developers to collaborate efficiently while maintaining a history of revisions.";
            }

            else if (question.Contains("what is a programming framework") || question.Contains("explain programming frameworks"))
            {
                return "A programming framework is like a toolkit for developers. It provides pre-built functions, libraries, and tools to simplify the development of applications, making coding more efficient.";
            }

            else if (question.Contains("what is an API in programming") || question.Contains("explain Application Programming Interfaces"))
            {
                return "An API is like a menu in a restaurant. It defines a set of rules and protocols for how software components should interact. It allows different software systems to communicate and share data.";
            }

            else if (question.Contains("what is a data structure") || question.Contains("explain data structures"))
            {
                return "A data structure is like a way to organize and store data effectively. Examples include arrays, lists, trees, and graphs, each with its own characteristics and best-use scenarios.";
            }

            else if (question.Contains("what is a software design pattern") || question.Contains("explain design patterns"))
            {
                return "A software design pattern is like a proven blueprint for solving common software design problems. They provide reusable solutions to common challenges in software development.";
            }

            else if (question.Contains("what is debugging in programming") || question.Contains("explain debugging"))
            {
                return "Debugging is like detective work in programming. It involves identifying and fixing errors or bugs in code to ensure that a program works correctly.";
            }

            else if (question.Contains("what is a coding convention") || question.Contains("explain coding conventions"))
            {
                return "Coding conventions are like grammar rules for code. They define a consistent style for writing code, making it more readable and maintainable. Examples include indentation, naming conventions, and comment guidelines.";
            }
            else if (question.Contains("what is the time") || question.Contains("time"))
            {
                return "I currently do not have access to a time feature";
            }







            // Here you can add more with multiple random answers

            else if (question.Contains("tell me a fact") || question.Contains("share a fun fact") || question.Contains("give me some trivia"))
            {
                Random random = new Random();
                int factNumber = random.Next(1, 4); // Choose a random fact

                switch (factNumber)
                {
                    case 1:
                        return "Did you know that honey never spoils? Archaeologists have found pots of honey in ancient Egyptian tombs that are over 3,000 years old and still perfectly edible.";
                    case 2:
                        return "Here's an interesting fact: The Eiffel Tower can be 15 cm taller during the summer due to the expansion of the iron in the heat.";
                    case 3:
                        return "An intriguing fact: Octopuses have three hearts. Two pump blood to the gills, and one pumps it to the rest of the body.";
                    case 4:
                        return "Here's a fun fact: The world's largest desert isn't the Sahara; it's Antarctica, as it receives very little precipitation.";
                    default:
                        return "Here's an amazing fact: A day on Venus is longer than its year. Venus rotates so slowly that a day on Venus (one full rotation) takes longer than a year on Venus (orbiting the Sun).";
                }
            }

            if (question.Contains("tell me a tech fact") || question.Contains("share a tech trivia") || question.Contains("give me tech information"))
            {
                Random random = new Random();
                int techFactNumber = random.Next(1, 4); // Choose a random tech fact

                switch (techFactNumber)
                {
                    case 1:
                        return "Did you know that the first computer programmer was a woman named Ada Lovelace? She wrote the first algorithm for Charles Babbage's Analytical Engine in the 1840s.";
                    case 2:
                        return "Here's a tech fact: The average smartphone has more computing power than the computers used for the Apollo 11 moon landing in 1969.";
                    case 3:
                        return "An interesting tech tidbit: The world's first website, created by Tim Berners-Lee, went live on August 6, 1991. It described the World Wide Web project and how to use a web browser.";
                    case 4:
                        return "Here's a tech trivia: The QWERTY keyboard layout, which is commonly used on most devices today, was designed in the 1870s for typewriters to prevent key jams.";
                    default:
                        return "Here's a tech fact: The term 'bug' in computer science originated from an actual insect. In 1947, a moth caused a malfunction in the Harvard Mark II computer, and engineers referred to it as a 'bug.'";
                }
            }

            if (question.Contains("tell me a space fact") || question.Contains("share an astronomy trivia") || question.Contains("give me space information"))
            {
                Random random = new Random();
                int spaceFactNumber = random.Next(1, 4); // Choose a random space fact

                switch (spaceFactNumber)
                {
                    case 1:
                        return "Did you know that a day on Venus is longer than its year? Venus rotates so slowly that a day on Venus (one full rotation) takes longer than a year on Venus (orbiting the Sun).";
                    case 2:
                        return "Here's a space fact: The largest volcano in our solar system is Olympus Mons on Mars. It's about 13.6 miles (22 kilometers) high, nearly three times the height of Mount Everest.";
                    case 3:
                        return "An interesting astronomy tidbit: If you were to scream in space, no one would hear you because there's no air to carry sound waves. Space is completely silent.";
                    case 4:
                        return "Here's a space trivia: The Hubble Space Telescope has captured images of galaxies that are billions of light-years away, allowing astronomers to glimpse the universe's distant past.";
                    default:
                        return "Here's a space fact: The Milky Way galaxy is estimated to be about 100,000 light-years in diameter and contains billions of stars, planets, and other celestial objects.";
                }
            }


            if (question.Contains("future of technology") || question.Contains("tech trends") || question.Contains("technology predictions"))
            {
                Random random = new Random();
                int responseNumber = random.Next(1, 4); // Choose a random response

                switch (responseNumber)
                {
                    case 1:
                        return "The future of technology looks promising with advancements in artificial intelligence, quantum computing, and renewable energy. We can expect more automation and smarter devices.";
                    case 2:
                        return "Tech trends include the growth of the Internet of Things (IoT), 5G connectivity, and the rise of decentralized finance (DeFi) based on blockchain technology.";
                    case 3:
                        return "In the coming years, we might see breakthroughs in space exploration, self-driving cars becoming more mainstream, and innovations in healthcare technology.";
                    case 4:
                        return "The technology landscape is evolving rapidly, and we can anticipate exciting developments in areas like augmented reality, virtual reality, and sustainable tech solutions.";
                    default:
                        return "The future of technology is full of possibilities, from advancements in clean energy to revolutionary changes in how we interact with machines and the digital world.";
                }
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
                Random random = new Random();
                int generalResponseNumber = random.Next(1, 4); // Choose a random general response

                switch (generalResponseNumber)
                {
                    case 1:
                        return "I'm sorry, I don't have a specific answer for that question.";
                    case 2:
                        return "I couldn't find a direct match for your question. Is there anything else you'd like to know?";
                    case 3:
                        return "It seems like your question is outside my current knowledge. Please feel free to ask something else, and I'll do my best to assist you.";
                    default:
                        return "I apologize, but I don't have a predefined response for that inquiry.";
                }
            }
        }
    }
}
