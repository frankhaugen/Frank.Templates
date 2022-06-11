using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLDotNet.Core;

public class MoviesDatareader
{
    private readonly FileInfo _fileInfo;
    private readonly List<string> _badRecords = new();

    public MoviesDatareader(string filePath)
    {
        _fileInfo = new FileInfo(filePath);
    }

    public bool FileExist() => _fileInfo.Exists;

    public IEnumerable<Movie> ReadAllJson()
    {
        var jsonSetting = new JsonSerializerOptions();
        jsonSetting.Converters.Add(new JsonStringEnumConverter());

        var movies = JsonSerializer.Deserialize<IEnumerable<Movie>>(_fileInfo.OpenRead(), jsonSetting);
        return movies ?? new List<Movie>();
    }

    public IEnumerable<CsvMovie> ReadAll()
    {
        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HasHeaderRecord = true,
            MissingFieldFound = MissingFieldFound,
            BadDataFound = BadDataFound,

        };

        var movies = new List<CsvMovie>();

        using (var reader = _fileInfo.OpenText())
        using (var csv = new CsvReader(reader, csvConfiguration))
        {
            csv.Context.RegisterClassMap<CsvMovieClassMap>();

            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                try
                {
                    var record = csv.GetRecord<CsvMovie>();
                    movies.Add(record);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    //throw;
                }
            }
        }

        //var csvReader = new CsvReader(_fileInfo.OpenText(), csvConfiguration);



        return movies ?? new List<CsvMovie>();
    }

    private void MissingFieldFound(MissingFieldFoundArgs args)
    {
        _badRecords.Add(args.HeaderNames.Join().AddNewLine().Add(args.Index.ToString()));
    }

    private void BadDataFound(BadDataFoundArgs args)
    {
        _badRecords.Add(args.RawRecord);
    }
}

public static class StringExtensions
{
    public static string Join(this IEnumerable<string>? source, string seperator = ", ") => string.Join(seperator, source ?? Array.Empty<string>());
    public static string Add(this string source, string value) => source + value;
    public static string AddNewLine(this string source) => source + Environment.NewLine;
}