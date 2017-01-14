using System;
using Xamarin.Forms;
using System.Net.Http;
using JeffWilcox.Utilities.Silverlight;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MarvelAPI {

    public partial class MainPage: ContentPage {

        private const int PAGE_SIZE = 20;

        private int currentPage = 1;
        private int lastPage = 1;

        HttpClient client;
        public MainPage() {
            InitializeComponent();

            Title = "Marvel";

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;


            characterList.ItemTapped += selectCharacter;

            loadCharacters(currentPage);
        }

        public async Task<Models.Result> getCharacters(int page) {
            string ts = ConvertToUnixTime(DateTime.Now);
            string privateKey = "44cc1306e479b2e0945a63076adbcf687833f20b";
            string publicKey = "6316ca71814e8d4fff1fff675a941907";
            string hash = MD5.GetMd5String(ts + privateKey + publicKey);
            var uri = new Uri(string.Format("https://gateway.marvel.com:443/v1/public/characters?apikey={0}&ts={1}&hash={2}&offset={3}&limit={4}", publicKey, ts, hash, Convert.ToString((page - 1) * PAGE_SIZE), Convert.ToString(PAGE_SIZE)));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Models.Result>(content);
            }
            return null;
        }

        public static String ConvertToUnixTime(DateTime datetime) {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return Convert.ToString((datetime - sTime).TotalSeconds);
        }

        public async void loadCharacters(int page) {
            activityIndicator.IsVisible = true;
            activityIndicator.IsRunning = true;
            var list = characterList;
            Models.Result result = await getCharacters(page);
            lastPage = result.data.total / PAGE_SIZE + 1;
            list.ItemsSource = result.data.results;
            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
        }

        public void selectCharacter(object sender, ItemTappedEventArgs args) {
            Models.Character character = args.Item as Models.Character;
            if (character == null)
                return;
            Navigation.PushAsync(new CharacterDetail(character));
        }

        public void loadNextPage(object sender, EventArgs args) {
            if (currentPage <= lastPage) {
                currentPage++;
                loadCharacters(currentPage);
            } else {
                DisplayAlert("Info", "There is no previous page.", "OK");
            }
        }

        public void loadPreviousPage(object sender, EventArgs args) {
            if (currentPage >= 1) {
                currentPage--;
                loadCharacters(currentPage);
            } else {
                DisplayAlert("Info", "There is no next page.", "OK");
            }
        }
    }
}
