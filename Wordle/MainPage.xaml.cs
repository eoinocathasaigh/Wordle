namespace Wordle
{
    public partial class MainPage : ContentPage
    {
        //Declaring Variables
        private Random rand;
        private List<string> gameWords;
        HttpClient http;
        private string userGuess;
        private string correctWord;
        private int gamesPlayed;
        public string userName;
        private string password;
        public string targetFile;
        public MainPage()
        {
            InitializeComponent();
            Title = "Welcome : " + userName;
        }

        public async Task getGameWords()
        {
            string target = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "GameWords.txt");
            if(File.Exists(target))
            {
                //Read file into a list
                StreamReader readToList = new StreamReader(target);
                string addMe = "Default";
                while ((addMe = readToList.ReadLine()) != null)
                {
                    gameWords.Add(addMe);
                }
                readToList.Close();
            }
            else
            {
                var hub = await http.GetAsync("https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt");
                if(hub != null)
                {
                    string listOfWords = await hub.Content.ReadAsStringAsync();
                    gameWords = new List<string>();

                    //Saving the contents to a file
                    StreamWriter writeWords = new StreamWriter(target);
                    {
                        writeWords.Write(listOfWords);
                    }
                    writeWords.Close();

                    //Reading the words from the file
                    StreamReader readToList = new StreamReader(target);
                    string addMe = "Default";
                    while((addMe =  readToList.ReadLine()) !=null)
                    {
                        gameWords.Add(addMe);
                    }
                    readToList.Close();
                }
            }
        }

        public void getRandWord()
        {
            rand = new Random();
            correctWord = gameWords[rand.Next(gameWords.Count)];

        }
        private void signIn(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignIn());
        }

    }

}
