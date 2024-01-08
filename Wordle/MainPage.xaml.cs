
using Wordle.ViewModel;

namespace Wordle;

public partial class MainPage : ContentPage
{
    bool fromsettingspage = false;

    public MainPage(WordleViewModel viewModel)
    {
        InitializeComponent();
        UpdateNameLabel();
        BindingContext = viewModel;
    }

    public async void NavSignIn_Clicked(object sender, EventArgs e)
    {
        SignIn setpage = new SignIn();
        fromsettingspage = true;
        await Navigation.PushAsync(setpage);
    }

    private void UpdateNameLabel()
    {
        if (!string.IsNullOrEmpty(App.CurrentUserName))
        {
            Title = "Currently Signed in: " + App.CurrentUserName;
        }
        else
        {
            Title = "Welcome to Wordle!";
        }
    }

    private async void Settings_Clicked(object sender, EventArgs e)
    {
        SettingsPage newSet = new SettingsPage();
        await Navigation.PushAsync(newSet);
    }

    private async void HowToPlay_Clicked(object sender, EventArgs e)
    {
        Info howto = new Info();
        await Navigation.PushAsync(howto);
    }
}
