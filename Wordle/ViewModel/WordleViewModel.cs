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

        //Correct Letters
        public class Words
        {
            public List<Letters> letters { get; set; }
        }

        public class Letters
        {
            public char userInput { get; set; }
            public char CorrectLetter {  get; set; }
            public Color bgCol { get; set; }
        }
    }
}
