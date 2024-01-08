using Microsoft.Maui.ApplicationModel;
using Wordle.ViewModel;

namespace Wordle;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void ToggleTheme_Clicked(object sender, EventArgs e)
    {

    }

    private async void DeleteAccount_Clicked(object sender, EventArgs e)
    {
        bool isLoggedIn = App.IsLoggedIn;

        if (isLoggedIn)
        {
            bool deleteConfirmed = await DisplayAlert("Confirm Deletion", "Are you sure you want to delete your account?", "Yes", "No");

            if (deleteConfirmed)
            {
                string userFile = App.CurrentUserName + ".txt";
                string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, userFile);

                if (File.Exists(targetFile))
                {
                    File.Delete(targetFile);
                    App.CurrentUserName = "";
                    App.IsLoggedIn = false;
                }
                await DisplayActionSheet("Profile Deleted", "Your Profile has been deleted\nWe're Sorry to see you go but we hope to see you again", "Goodbye");
                await Navigation.PushAsync(new SignIn());
            }
        }
        else
        {
            await DisplayAlert("Not Logged In", "You're not logged in to delete your account.", "OK");
        }
    }

    private async void MuteSound_Clicked(object sender, EventArgs e)
    {
        if (App.SoundMuted)
        {
            bool muteNoise = await DisplayAlert("Are you sure?", "All sound in the game will be unmuted", "Yes", "No");
            App.SoundMuted = false;
        }
        else
        {
            bool muteNoise = await DisplayAlert("Are you sure?", "All sound in the game will be muted", "Yes", "No");
            App.SoundMuted = true;
        }
    }
}