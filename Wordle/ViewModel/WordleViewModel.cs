using CommunityToolkit.Mvvm.ComponentModel;
using Wordle.Models;
using CommunityToolkit.Mvvm.Input;

namespace Wordle.ViewModel
{
    public partial class WordleViewModel: ObservableObject
    {
        //Declaring Variables
        [ObservableProperty]
        public GameRows[] currentRow;
        private int currentRowIndex;
        private int currentColumnIndex;
        char[] answer;
        char[] userGuess;
        public char[] KeyboardRow1 { get; }
        public char[] KeyboardRow2 { get; }
        public char[] KeyboardRow3 { get; }

        //Constructor to initialize some of the aspects of the ViewModel
        public WordleViewModel()
        {
            currentRow = new GameRows[6]
            {
                new GameRows(),
                new GameRows(),
                new GameRows(),
                new GameRows(),
                new GameRows(),
                new GameRows()
            };
            //Testing storing the correct answer
            answer = "tests".ToCharArray();
            KeyboardRow1 = "QWERTYUIOP".ToCharArray();
            KeyboardRow2 = "ASDFGHJKL".ToCharArray();
            KeyboardRow3 = "<ZXCVBNM>".ToCharArray();
        }

        //Getting the user to the next time every time they hit enter
        //[ICommand]
        public void NextLine()
        {
            //Controlling when to move the user to the next row
            var correct = currentRow[currentRowIndex].ValidateAnswer(answer);

            if (correct)
            {
                App.Current.MainPage.DisplayAlert("You Win!", "You are so smart!", "OK");
                return;
            }

            if (currentRowIndex == 5)
            {
                App.Current.MainPage.DisplayAlert("Game Over!", "You are out of turns", "OK");
            }
            else
            {
                currentRowIndex++;
                currentColumnIndex = 0;
            }
        }
        [ICommand]
        public void UserEntry(char userEntry)
        {
            if(userEntry == '>')
            {
                NextLine();
                return;
            }
            
            if(userEntry == '<')
            {
                if (currentColumnIndex == 0)
                    return;
                currentColumnIndex--;
                currentRow[currentRowIndex].CorrectLetters[currentColumnIndex].UserInput = ' ';
                return;
            }

            if(currentColumnIndex == 5)
            {
                return;
            }

            currentRow[currentRowIndex].CorrectLetters[currentColumnIndex].UserInput = userEntry;
            currentColumnIndex++;
        }
    }
}
