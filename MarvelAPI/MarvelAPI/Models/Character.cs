namespace MarvelAPI.Models {
    public class Character {

        const string IMAGE_SIZE_SMALL = "portrait_small";

        const string IMAGE_SIZE_MEDIUM = "portrait_medium";

        const string IMAGE_SIZE_LARGE = "portrait_xlarge";

        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public ComicSummary comics { get; set; }

        public Image thumbnail { get; set; }

        public string smallThumbnailUrl {
            get {
                return string.Format("{0}/{1}.{2}", thumbnail.path, IMAGE_SIZE_SMALL, thumbnail.extension);
            }
        }

        public string mediumThumbnailUrl {
            get {
                return string.Format("{0}/{1}.{2}", thumbnail.path, IMAGE_SIZE_MEDIUM, thumbnail.extension);
            }
        }

        public string largeThumbnailUrl {
            get {
                return string.Format("{0}/{1}.{2}", thumbnail.path, IMAGE_SIZE_LARGE, thumbnail.extension);
            }
        }
    }
}
