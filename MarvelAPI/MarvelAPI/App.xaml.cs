using Xamarin.Forms;

namespace MarvelAPI {
    public partial class App: Application {
        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new MarvelAPI.MainPage());

            MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, "#000000");

            MainPage.SetValue(NavigationPage.BackgroundColorProperty, "#101010");

            MainPage.SetValue(NavigationPage.BarTextColorProperty, "#FFFFFF");
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
