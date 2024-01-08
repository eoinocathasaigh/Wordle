using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Storage;
using Wordle.Model;

namespace Wordle.ViewModel;

public partial class WordleViewModel : ObservableObject
{
    int rowIndex;
    int columnIndex;
    private int numWords;
    char[] correctAnswer;
    public string targetFile;
    string RandWord;
    public string playerName = App.CurrentUserName;
    private Random rand;
    private List<string> gameWords;
    private HttpClient http;
    public bool StartAgain;

    public char[] KeyboardRow1 { get; }
    public char[] KeyboardRow2 { get; }
    public char[] KeyboardRow3 { get; }

    [ObservableProperty]
    private GameRows[] rows;

    public WordleViewModel()
    {
        rows = new GameRows[6];
        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = new GameRows();
        }
        //GETTING A RANDOM WORD FROM THE LIST OF WORDS AND THEN SETTING UP THE GAME USING IT
        gameWords = new List<string>();
        numWords = gameWords.Count;
        getGameWords();
        GetRandWord();
        RandWord = RandWord.ToUpper();
        correctAnswer = RandWord.ToCharArray();
        KeyboardRow1 = "QWERTYUIOP".ToCharArray();
        KeyboardRow2 = "ASDFGHJKL".ToCharArray();
        KeyboardRow3 = "<ZXCVBNM>".ToCharArray();
    }

    //Method that fires whenever the user enters their answer
    //It will evaluate their choice and display the appropriate information depending on the answer
    public void Enter()
    {
        if (columnIndex != 5)
            return;

        var correct = Rows[rowIndex].ValidateWithDelay(correctAnswer);

        if (correct)
        {

            if (rowIndex < 5)
            {
                App.Current.MainPage.DisplayAlert("You Win!", "Congratulations " + playerName + ", I think I have feelings for you", "OK");
                ResetGame();
            }
            App.Current.MainPage.DisplayAlert("You Win!", "Congratulations" + playerName + ", just in the nick of time too!\nI think I have feelings for you", "OK");
            ResetGame();
        }

        if (rowIndex == 5)
        {
            App.Current.MainPage.DisplayAlert("Game Over!", "Correct Answer was " + RandWord, "OK");
            ResetGame();
        }
        else
        {
            rowIndex++;
            columnIndex = 0;
        }
    }

    //User is prompted with an Alert that gives them the choice of starting again
    public async Task<bool> ShowRestartConfirmation()
    {
        return await App.Current.MainPage.DisplayAlert("Unfortunately the game is over :(", "But dont be upset\nYou can start a new game!\nWould you like to start a new game?", "Yes", "No");
    }

    [ICommand]
    // Method to restart the game when the user either wins or looses
    public async void ResetGame()
    {
        bool restart = await ShowRestartConfirmation();
        if (restart)
        {
            // Reset the game
            rowIndex = 0;
            columnIndex = 0;
            StartAgain = false;
            foreach (var row in rows)
            {
                foreach (var letter in row.Letters)
                {
                    letter.Input = ' ';
                    letter.Color = Colors.White;
                }
            }
            getGameWords();
            GetRandWord();
            RandWord = RandWord.ToUpper();
            correctAnswer = RandWord.ToCharArray();
        }
        else
        {

            return;
        }
    }

    //Command Handeling the users choice of character
    [ICommand]
    public void EnterLetter(char letter)
    {
        if (letter == '>')
        {
            Enter();
            return;
        }

        if (letter == '<')
        {
            HandleBackspace();
            return;
        }

        HandleLetterInput(letter);
    }

    private void HandleBackspace()
    {
        if (columnIndex == 0)
            return;

        columnIndex--;
        Rows[rowIndex].Letters[columnIndex].Input = ' ';
    }

    private void HandleLetterInput(char letter)
    {
        if (columnIndex == 5)
            return;

        Rows[rowIndex].Letters[columnIndex].Input = letter;
        columnIndex++;
    }

    public async Task getGameWords()
    {
        targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "words.txt");
        if (!File.Exists(targetFile))
        {
            http = new HttpClient();
            var response = await http.GetAsync("https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt");

            if (response.IsSuccessStatusCode)
            {
                string contents = await response.Content.ReadAsStringAsync();
                using (StreamWriter writer = new StreamWriter(targetFile))
                {
                    writer.Write(contents);
                }

                using (StreamReader s = new StreamReader(targetFile))
                {
                    string line = "";
                    while ((line = s.ReadLine()) != null)
                    {
                        gameWords.Add(line);
                        Console.WriteLine(line);
                        numWords++;
                    }
                }
            }
        }
        else
        {
            using (StreamReader s = new StreamReader(targetFile))
            {
                string line = "";
                while ((line = s.ReadLine()) != null)
                {
                    gameWords.Add(line);
                    Console.WriteLine(line);
                    numWords++;
                }
            }
        }
    }

    public string GetRandWord()
    {
        rand = new Random();
        return new string(RandWord = gameWords[rand.Next(gameWords.Count)]);
    }
}
