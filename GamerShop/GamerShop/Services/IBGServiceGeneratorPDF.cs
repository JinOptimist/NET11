namespace GamerShop.Services
{
    public interface IBGServiceGeneratorPDF
    {
        int heroCount { get; }
        int AllheroCount { get; }
        bool IsReady { get; }

        string? ResultPath { get; }
        bool Report(string path,List<string> heroName);
    }
}
