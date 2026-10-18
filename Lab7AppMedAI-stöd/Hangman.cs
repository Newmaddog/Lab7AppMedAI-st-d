using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7AppMedAI_stöd
{
    internal class Hangman
    {
        WordManager wordManager = new WordManager();
        //list to use if the user have guess the correct word comparing with theWord
        private List<char> userGuessWordList = new List<char>();
        //the correct word that user need to guess
        private string theWord;
        //how many guesses the user have
        private int guessAttempt = 6;
        private int guessUsed = 0;

        //to help clear the terminal when i wanted
        private bool clearTerminal = false;

        //Save all letter that user have guess
        List<char> letterGuessList = new List<char>();

        public void StartGame()
        {
            //get the word to guess and help me
            theWord = wordManager.GetRandomWord();
            for (int i = 0; i < theWord.Length; i++)
            {
                userGuessWordList.Add('-');
            }

            Console.WriteLine("Welcome to Hangman!");

            //loop but i learn from ai about the sequenceEqual
            while (!userGuessWordList.SequenceEqual(theWord) && guessUsed < guessAttempt)
            {
                if (guessAttempt != 0 && clearTerminal == true)
                {
                    Console.Clear();
                }
                //sort the guess letter 
                letterGuessList.Sort();
                clearTerminal = true;
                //it onlt draw the hangman and have different stage base on fail guess
                wordManager.DrawHangman(guessUsed);

                Console.WriteLine();
                Console.WriteLine("Word: " + string.Concat(userGuessWordList));
                wordManager.ShowGuessedLetters(letterGuessList, theWord);
                Console.WriteLine("Wrong guesses: " + guessUsed +
                                  "/" + guessAttempt);
                Console.Write("Guess a letter: ");

                //learn from ai that if the readline return null the ?? change to ""
                string input = Console.ReadLine() ?? "";

                if (input.Length!=1 || !char.IsLetter(input[0]))
                {
                    Console.Clear();
                    clearTerminal = false;
                    Console.WriteLine("Please enter one letter.");
                    continue;
                }
                input = input.ToLower();
                if (letterGuessList.Contains(input[0]))
                {
                    Console.Clear();
                    clearTerminal = false;
                    Console.WriteLine($"You have already guess the letter: {input}");
                    continue;
                }

                letterGuessList.Add(input[0]);

                if (theWord.Contains(input))
                {
                    for (int i = 0; i < theWord.Length; i++)
                    {
                        if (theWord[i] == input[0])
                        {
                            userGuessWordList[i] = theWord[i];
                        }
                    }
                    Console.WriteLine("Correct guess!");
                }
                else
                {
                    guessUsed++;
                    clearTerminal = false;
                    Console.Clear();
                    Console.WriteLine("Wrong guess!");
                }
            }

            if (userGuessWordList.SequenceEqual(theWord))
            {
                Console.WriteLine("You won!");
                Console.WriteLine("The word was: " + theWord);
            }
            else
            {
                Console.Clear();
                wordManager.DrawHangman(6);

                Console.WriteLine("You lost!");
                Console.WriteLine("The word was: " + theWord);
            }
        }
    }
}
