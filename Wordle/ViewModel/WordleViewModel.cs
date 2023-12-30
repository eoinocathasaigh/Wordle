using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.ViewModel
{
    public partial class WordleViewModel: ObservableObject
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
            public void Validate(char[] correctWord)
            {

            }
        }

        public partial class Letters: ObservableObject
        {
            [ObservableProperty]
            private char userInput;
            [ObservableProperty]
            private Color colorChange;
            public char CorrectLetter {  get; set; }
            public Color bgCol { get; set; }
        }
    }
}
