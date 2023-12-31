namespace Wordle
{
    public partial class App : Application
    {
        public App(MainPage newPage)
        {
            InitializeComponent();

            MainPage = newPage;
        }
    }
}
