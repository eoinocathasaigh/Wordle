using CommunityToolkit.Mvvm.ComponentModel;

namespace Wordle.Model;

public class GameRows
{
    DisplayRotation rotation = new DisplayRotation();
    public GameRows()
    {

        Letters = new Letter[5];
        for (int i = 0; i < Letters.Length; i++)
        {
            Letters[i] = new Letter();
        }
    }

    public Letter[] Letters { get; set; }

    public bool ValidateWithDelay(char[] correctAnswer)
    {
        int count = 0;

        //loops through stuff.
        for (int i = 0; i < Letters.Length; i++)
        {
            var letter = Letters[i];
            if (letter.Input == correctAnswer[i])
            {
                letter.Color = Colors.Green;
                count++;
            }
            else if (correctAnswer.Contains(letter.Input))
            {
                letter.Color = Colors.Yellow;
            }
            else
            {
                letter.Color = Colors.Gray;
            }

            Task.Delay(1000);
        }

        return count == 5;
    }
}

public partial class Letter : ObservableObject
{
    public Letter()
    {
        Color = Colors.White;
    }

    [ObservableProperty]
    private char input;

    [ObservableProperty]
    private Color color;
}
