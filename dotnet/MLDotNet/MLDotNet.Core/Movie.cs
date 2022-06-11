using CsvHelper.Configuration;

namespace MLDotNet.Core;

public class Movie
{
    public bool Adult { get; set; }
    //public string? BelongsToCollection { get; set; }
    //public float Budget { get; set; }
    //public string? Genres { get; set; }
    //public string? Homepage { get; set; }
    public float Id { get; set; }
    public string ImdbId { get; set; }
    //public string? OriginalLanguage { get; set; }
    //public string? OriginalTitle { get; set; }
    //public string? Overview { get; set; }
    public float Popularity { get; set; }
    //public string? PosterPath { get; set; }
    //public string? ProductionCompanies { get; set; }
    //public string? ProductionCountries { get; set; }
    public string ReleaseDate { get; set; }
    public float Revenue { get; set; }
    public float Runtime { get; set; }
    //public string? SpokenLanguages { get; set; }
    //public string? Status { get; set; }
    public string Tagline { get; set; }
    public string Title { get; set; }
    public bool Video { get; set; }
    public float VoteAverage { get; set; }
    public float VoteCount { get; set; }
}

public class CsvMovie
{
    public bool Adult { get; set; }
    public string BelongsToCollection { get; set; }
    public int Budget { get; set; }
    public string Genres { get; set; }
    public string Homepage { get; set; }
    public int Id { get; set; }
    public string ImdbId { get; set; }
    public string OriginalLanguage { get; set; }
    public string OriginalTitle { get; set; }
    public string Overview { get; set; }
    public double Popularity { get; set; }
    public string PosterPath { get; set; }
    public string ProductionCompanies { get; set; }
    public string ProductionCountries { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Revenue { get; set; }
    public double Runtime { get; set; }
    public string SpokenLanguages { get; set; }
    public string Status { get; set; }
    public string Tagline { get; set; }
    public string Title { get; set; }
    public bool Video { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
}

public class CsvMovieClassMap : ClassMap<CsvMovie>
{
    public CsvMovieClassMap()
    {
        Map(m => m.Adult).Name("adult");
        Map(m => m.BelongsToCollection).Name("belongs_to_collection");
        Map(m => m.Budget).Name("budget");
        Map(m => m.Genres).Name("genres");
        Map(m => m.Homepage).Name("homepage");
        Map(m => m.Id).Name("id");
        Map(m => m.ImdbId).Name("imdb_id");
        Map(m => m.OriginalLanguage).Name("original_language");
        Map(m => m.OriginalTitle).Name("original_title");
        Map(m => m.Overview).Name("overview");
        Map(m => m.Popularity).Name("popularity");
        Map(m => m.PosterPath).Name("poster_path");
        Map(m => m.ProductionCompanies).Name("production_companies");
        Map(m => m.ProductionCountries).Name("production_countries");
        Map(m => m.ReleaseDate).Name("release_date");
        Map(m => m.Revenue).Name("revenue");
        Map(m => m.Runtime).Name("runtime");
        Map(m => m.SpokenLanguages).Name("spoken_languages");
        Map(m => m.Status).Name("status");
        Map(m => m.Tagline).Name("tagline");
        Map(m => m.Title).Name("title");
        Map(m => m.Video).Name("video");
        Map(m => m.VoteAverage).Name("vote_average");
        Map(m => m.VoteCount).Name("vote_count");
    }
}