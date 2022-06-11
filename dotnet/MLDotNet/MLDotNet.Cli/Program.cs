// See https://aka.ms/new-console-template for more information

using Microsoft.ML;
using Microsoft.ML.AutoML;
using MLDotNet.Core;

var mLContext = new MLContext();

Console.WriteLine("Hello, World!");

var reader = new MoviesDatareader(Path.Combine(AppContext.BaseDirectory, "movies.csv"));
var exist = reader.FileExist();

Console.WriteLine(exist.ToString());

var dataView = mLContext.Data.LoadFromEnumerable<CsvMovie>(reader.ReadAll());
var experiment = mLContext.Auto().CreateRecommendationExperiment(60);
var result = experiment.Execute(dataView, nameof(CsvMovie.Popularity));

Console.WriteLine(result.BestRun.ValidationMetrics);

//ConsoleTableBuilder.From(reader.ReadAll().Take(512).ToList()).WithFormat(ConsoleTableBuilderFormat.Minimal).ExportAndWriteLine();