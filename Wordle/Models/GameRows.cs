using CommunityToolkit.Mvvm.ComponentModel;

namespace Wordle.Models
{
    public class GameRows
    {
        //Declaring Variables
        int currentRow;
        int currentCol;
        char[] answer;
        char[] userGuess;

        //Constructor to initialize some of the variables of the Model class
        public GameRows()
        {
            CorrectLetters = new Letters[5]
            {
                new Letters(),
                new Letters(),
                new Letters(),
                new Letters(),
                new Letters(),
            };
        }

        //Correct Letters
        public Letters[] CorrectLetters { get; set; }
        public bool ValidateAnswer(char[] correctWord)
        {
            int count = 0;

            for (int i = 0; i < CorrectLetters.Length; i++)
            {
                var letter = CorrectLetters[i];
                if (letter.UserInput == answer[i])
                {
                    letter.ColorChange = Colors.Green;
                    count++;
                }
                else if (answer.Contains(letter.UserInput))
                {
                    letter.ColorChange = Colors.Yellow;
                }
                else
                {
                    letter.ColorChange = Colors.Gray;
                }
            }
            return count == 5;
        }   
    }
    public partial class Letters : ObservableObject
    {
        [ObservableProperty]
        private char userInput;
        [ObservableProperty]
        private Color colorChange;
        public char CorrectLetter { get; set; }
        public Color bgCol { get; set; }
    }
}
