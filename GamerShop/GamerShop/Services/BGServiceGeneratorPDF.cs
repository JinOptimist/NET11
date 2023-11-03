using System.Text;
using BusinessLayerInterfaces.BgServices;

namespace GamerShop.Services
{
    public class BGServiceGeneratorPDF : IBGServiceGeneratorPDF
    {
        public int heroCount { get; private set; }

        public int AllheroCount { get; private set; }

        public bool Report(string path,List<string> heroNames)
        {
            AllheroCount = heroNames.Count;
            var pdf = new ChromePdfRenderer();
            var html = new StringBuilder();
            html.Append($"<h1>Hero List </h1>");
            

            foreach (var heroName in heroNames)
            {
                html.Append($"<span>Hero: {heroName}</span>");
                heroCount++;
            }

            var file = pdf.RenderHtmlAsPdf(html.ToString());
            file.SaveAs(path);
            return true;

        }
    }
}
