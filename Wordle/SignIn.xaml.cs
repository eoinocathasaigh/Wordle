namespace Wordle;

public partial class SignIn : ContentPage
{
	//Initializing variables for this particular class and the others that may need them
	public string userName;
	private string userPass;
	public string userFile;

	public SignIn()
	{
		InitializeComponent();
	}

    private void Save_Clicked(object sender, EventArgs e)
    {
		userName = name.Text;
		userPass = password.Text;
		userFile = userName + ".txt";

		if(File.Exists(userFile))
		{
			DisplayAlert("Hello Again!", "Welcome back " + userName, "Hello Again");
		}
		else
		{
			DisplayAlert("Welcome Newcommer", "Its nice to see a new face", "Okay");
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, userFile);
            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            streamWriter.WriteAsync(userName);
            streamWriter.WriteAsync(userPass);

            Navigation.PushAsync(new MainPage());
        }
    }
}