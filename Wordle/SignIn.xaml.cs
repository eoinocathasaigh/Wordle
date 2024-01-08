using Wordle.ViewModel;

namespace Wordle
{
    public partial class SignIn : ContentPage
    {
        public string userName;
        private string userPass;
        public string userFile;


        WordleViewModel newView = new WordleViewModel();

        public SignIn()
        {
            InitializeComponent();
            if (App.IsLoggedIn)
            {
                Title = "Currently Signed in: " + App.CurrentUserName;
            }
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            userName = name.Text;
            userPass = password.Text;
            userFile = userName + ".txt";
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, userFile);

            if (File.Exists(targetFile))
            {
                using StreamReader streamReader = new StreamReader(targetFile);
                string fileContent = await streamReader.ReadToEndAsync();
                string[] lines = fileContent.Split(Environment.NewLine);
                Title = "Currently Signed in: " + userName;

                if (lines.Length >= 2 && lines[1] == userPass)
                {
                    await DisplayAlert("Welcome Back!", "Login Successful for " + userName, "Okay");
                    App.IsLoggedIn = true;
                    App.CurrentUserName = userName;
                    await Navigation.PushAsync(new MainPage(newView));
                }
                else
                {
                    await DisplayAlert("Invalid Password", "Please enter the correct password", "Okay");
                }
            }
            else
            {
                await DisplayAlert("New User", "Creating your account", "Okay");
                using StreamWriter streamWriter = new StreamWriter(targetFile);
                await streamWriter.WriteAsync(userName + Environment.NewLine + userPass);
                App.CurrentUserName = userName;
                App.IsLoggedIn = true;
                await Navigation.PushAsync(new MainPage(newView));
            }
        }

        private async void SignOut_Clicked(object sender, EventArgs e)
        {
            if (App.IsLoggedIn)
            {
                bool signOut = await DisplayAlert("Sign Out", "Are you sure you want to sign out?", "Yes", "Cancel");

                if (signOut)
                {
                    App.IsLoggedIn = false;
                    App.CurrentUserName = "";
                    Title = "Sign in or Sign Up";
                }
            }
            else
            {
                await DisplayAlert("Hang on a second", "You aren't even signed in!", "Okay");
            }
        }
    }
}