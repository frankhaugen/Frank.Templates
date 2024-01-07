
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
    
AnsiConsole.Write(new FigletText($"{config["Name"]!}").Color(Color.Green));
AnsiConsole.WriteLine("");

var kernel = TODO;

AnsiConsole.Status().Start("Initializing...", ctx =>
{
    ctx.Spinner(Spinner.Known.Star);
    ctx.SpinnerStyle(Style.Parse("green"));
    kernel = new TODO(config["TODO:Model"], config["TODO:BaseUrl"], new HttpClient(), null);
    ctx.Status("Initialized");
});

const string prompt = "1.\tPrompt kernel";
const string exit = "2.\tExit";

await Run();

return;

async Task Run()
{
    while (true)
    {
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(prompt, exit)
        );

        switch (option)
        {
            case prompt:
                await Prompt();
                break;
            case exit:
                return;
        }
    }
}

async Task Prompt()
{
    var userPrompt = AnsiConsole.Prompt(new TextPrompt<string>($"What can {config["TODO:Model"]} do for you?").PromptStyle("teal"));

    IReadOnlyList<TextContent> result = null;
    
    await AnsiConsole.Status().StartAsync("Processing...", async ctx =>
    {
        ctx.Spinner(Spinner.Known.Star);
        ctx.SpinnerStyle(Style.Parse("green"));
        ctx.Status($"Processing input to generate cypher");
        if (kernel != null) result = await kernel.GetTextContentsAsync(userPrompt);
    });
    
    if (result == null)
    {
        AnsiConsole.WriteLine("");
        AnsiConsole.Write(new Rule("[red]Cypher[/]") { Justification = Justify.Center });
        AnsiConsole.WriteLine("IS NULL!!!");
        AnsiConsole.Write(new Rule("[red]Cypher Execution Error[/]") { Justification = Justify.Center });
        AnsiConsole.WriteLine("");
        return;
    }

    if (result.Any())
    {
        foreach (var textContent in result)
        {
            AnsiConsole.WriteLine("");
            AnsiConsole.Write(new Rule("[cyan]Cypher[/]") { Justification = Justify.Center });
            if (textContent.ModelId != null) AnsiConsole.WriteLine(textContent.ModelId);
            if (textContent.Text != null)
                AnsiConsole.Write(new Panel(textContent.Text)
                    .Header("Result")
                    .Expand()
                    .RoundedBorder()
                    .BorderColor(Color.Green));
            AnsiConsole.WriteLine("");
        }
    }
    else
    {
        AnsiConsole.WriteLine("");
        AnsiConsole.Write(new Rule("[red]Cypher[/]") { Justification = Justify.Center });
        AnsiConsole.WriteLine("IS EMPTY!!!");
        AnsiConsole.Write(new Rule("[red]Cypher Execution Error[/]") { Justification = Justify.Center });
        AnsiConsole.WriteLine("");
    }
}
