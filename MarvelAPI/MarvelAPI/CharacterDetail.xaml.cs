using Xamarin.Forms;

namespace MarvelAPI {
    public partial class CharacterDetail: ContentPage {
        public CharacterDetail(Models.Character character) {
            InitializeComponent();

            Title = character.name;
            thumbnail.Source = character.mediumThumbnailUrl;
            description.Text = character.description;
            comicList.ItemsSource = character.comics.items;
        }
    }
}
