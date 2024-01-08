using Wordle.ViewModel;

namespace Wordle
{
    public partial class App : Application
    {
        //Variable to control the name at the top of each page
        public static string CurrentUserName { get; set; }
        public static bool IsLoggedIn { get; internal set; }
        public static bool SoundMuted { get; internal set; }
        public static bool isLightTheme {  get; internal set; } = true;

        public App()
        {

            InitializeComponent();
            MainPage = new AppShell();
            
            
        }
    }
}
