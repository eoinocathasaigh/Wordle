using System.Collections.ObjectModel;
using System.Net.Http;

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
            Task task = getGameWords();
            DisplayAlert("Test", correctWord, "Okay");
        }

        public async Task getGameWords()
        {
            /*
            if (gameWords.Count > 0)
            {
                return;
            }*/
            targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "words.txt");
            if (!File.Exists(targetFile))
            {
                http = new HttpClient();
                var response = await http.GetAsync("https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt");

                if (response.IsSuccessStatusCode)
                {
                    string contents = await response.Content.ReadAsStringAsync();
                    using (StreamWriter writer = new StreamWriter(targetFile))
                    {
                        writer.Write(contents);
                    }
                }
            }
            else
            {
                using (StreamReader s = new StreamReader(targetFile))
                {
                    string line = "";
                    while ((line = s.ReadLine()) != null)
                    {
                        gameWords.Add(line);
                        Console.WriteLine(line);
                    }
                }
            }
            getRandWord();
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
