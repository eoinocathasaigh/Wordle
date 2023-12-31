using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.Models
{
    public partial class GameRows: ObservableObject
    {
        //Declaring Variables
        int currentRow;
        int currentCol;
        char[] answer;
        char[] userGuess;

        //Correct Letters
        public class Words
        {
            public Letters[] CorrectLetters { get; set; }
            public void ValidateAnswer(char[] correctWord)
            {

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
}
