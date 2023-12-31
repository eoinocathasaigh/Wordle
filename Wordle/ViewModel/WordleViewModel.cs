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
        }

        //Getting the user to the next time every time they hit enter
        //[ICommand]
        public void nextLine()
        {
            //Controlling when to move the user to the next row
            var isValid = true;
            if(isValid)
            {
                if(currentColumnIndex != 5)
                {
                    return;
                }

                if(currentRowIndex == 5)
                {

                }
                else
                {
                    currentRowIndex++;
                    currentColumnIndex = 0;
                }
            }
        }
        //[ICommand]
        public void userEntry()
        {
            if(currentColumnIndex == 5)
            {
                return;
            }
        }
    }
}
