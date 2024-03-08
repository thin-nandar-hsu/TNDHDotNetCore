namespace DotNetTrainingTest.HWArtApi.Models
{
    public class ArtDataModel
    {
        public int ArtId { get; set; }
        public string ArtName { get; set; }
        public string ArtDescription { get; set; }
        public string ArtImageUrl { get; set; }
    }

    public class ArtViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PictureUrl { get; set; }
    }


    public class ArtByIdDataModel
    {
        public Artist Artist { get; set; }
        public Art[] Arts { get; set; }
    }

    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public Social[] Social { get; set; }
        public string ArtistImageUrl { get; set; }
    }

    public class Social
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public class Art
    {
        public int ArtId { get; set; }
        public string ArtName { get; set; }
        public string ArtDescription { get; set; }
        public string ArtImageUrl { get; set; }
    }

    public class ArtByIdViewModel
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string FaceBookAccount { get; set; }
        public Art[] ArtList { get; set; }
    }


}
