using System.Collections.Generic;

namespace SpotifySharp.Model
{
    public class Category
    {
        public string Href { get; set; }

        public IList<Image> Icons { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}