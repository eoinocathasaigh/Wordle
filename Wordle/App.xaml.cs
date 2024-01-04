namespace Wordle
{
    public partial class App : Application
    {
        public App(WelcomePage newGame)
        {
            InitializeComponent();

            MainPage = newGame;
        }
    }
}
