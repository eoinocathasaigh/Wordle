namespace Wordle;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
        InitializeComponent();
	}

    private void playGame_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Welcome to Wordle!", "Wordle is the interactive word guessing game in which you're given 6 guesses to figure out the secret word\nSimply Type in your word to begin" +
            "\nBoxes will turn: \nYellow if the letter is in the word but not in the correct spot" +
            "\nGray if the letter isnt in the word at all" +
            "\nAnd Green if the letter is both in the word and in the correct place" ,"Awesome, Lets go!");
        Shell.Current.GoToAsync("//MainPage");
    }

    private void signIn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//SignIn");
    }
}