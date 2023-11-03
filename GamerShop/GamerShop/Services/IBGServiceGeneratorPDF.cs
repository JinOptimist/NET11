namespace GamerShop.Services
{
    public interface IBGServiceGeneratorPDF
    {
        bool Report(string path,List<string> heroName);
    }
}
