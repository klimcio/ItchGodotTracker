namespace ItchGodotTracker.Common
{
    public class ItchGame
    {
        public Uri? Url { get; set; }
        public string Uploader { get; set; }
        public string[] Authors { get; set; }
        public string[] Tags { get; set; }
        public string[] Inputs { get; set; }
        public string[] Languages { get; set; }
        public string[] Platforms { get; set; }
        public DateTime? Published { get; set; }
        public string Status { get; set; }
        public string Genre { get; set; }
        public string MadeWith { get; set; }
        public string AverageSession { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? Updated { get; set; }
        public string[] Accessibility { get; set; }
        public string[] Links { get; set; }
        public string[] Mentions { get; set; }

        internal ItchGame(Uri? url,
            string[] authors,
            string uploader,
            string[] tags,
            string[] inputs,
            DateTime? published,
            string[] languages,
            string status,
            string[] platforms,
            string genre,
            string madeWith,
            string averageSession,
            DateTime? releaseDate,
            DateTime? updated,
            string[] accessibility,
            string[] links, 
            string[] mentions)
        {
            Authors = authors;
            Url = url;
            Uploader = uploader;
            Tags = tags;
            Inputs = inputs;
            Published = published;
            Languages = languages;
            Status = status;
            Platforms = platforms;
            Genre = genre;
            MadeWith = madeWith;
            AverageSession = averageSession;
            ReleaseDate = releaseDate;
            Updated = updated;
            Accessibility = accessibility;
            Links = links;
            Mentions = mentions;
        }
    }
}