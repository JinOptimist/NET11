namespace GamerShop.Services
{
    public interface IPdfGeneratorService
    {
        int PerfomedUserCount { get; }
        int AllUserCount { get; }
        string? ResultPath { get; }
        bool IsReady { get; }
        bool GeneratePdfWithUsers(string path, List<string> userNames);
    }
}