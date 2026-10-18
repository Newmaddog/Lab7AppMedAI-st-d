using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7AppMedAI_stöd
{
    internal class WordManager
    {
        //ai gave me the words and array with string
        private string[] words = { "apple", "computer", "school", "banana" };
        private Random random = new Random();

        public string GetRandomWord()
        {
            //Ai gavem me this tips
            int randomIndex = random.Next(words.Length);
            return words[randomIndex];
        }
        //this ide was mine i only use ai to help me draw but the function was all mine
        public void DrawHangman(int aStage)
        {
            switch (aStage)
            {
                case 0:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;

                case 1:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;

                case 2:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;

                case 3:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;

                case 4:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;

                case 5:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" /    |");
                    Console.WriteLine("=========");
                    break;

                case 6:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" / \\  |");
                    Console.WriteLine("=========");
                    break;
            }
        }

        //This was mine, i wante the user to know what letters was used and change collor of the correct letters
        public void ShowGuessedLetters(List<char> letterList, string correctLetter)
        {
            Console.Write("Letters guessed: ");

            foreach (char letter in letterList)
            {
                foreach (char rightLetter in correctLetter)
                {
                    if (rightLetter == letter)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
                Console.Write($"{letter}");
                Console.ResetColor();
                Console.Write(", ");
            }
            Console.WriteLine();
        }
    }
}
