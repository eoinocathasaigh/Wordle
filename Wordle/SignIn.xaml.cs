namespace Wordle;

public partial class SignIn : ContentPage
{
	//Initializing variables for this particular class and the others that may need them
	public string userName;
	private string userPass;

	public SignIn()
	{
		InitializeComponent();
	}

    private void Save_Clicked(object sender, EventArgs e)
    {
		userName = name.Text;
		userPass = password.Text;
    }
}