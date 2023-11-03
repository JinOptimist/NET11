using System.Text;
using BusinessLayerInterfaces.BgServices;

namespace GamerShop.Services
{
    public class BGServiceGeneratorPDF : IBGServiceGeneratorPDF
    {
        public int heroCount { get; private set; }

        public int AllheroCount { get; private set; }

        public bool IsReady { get; private set; }

        public string? ResultPath { get; private set; }

        public bool Report(string path,List<string> heroNames)
        {
            AllheroCount = heroNames.Count;
            var pdf = new ChromePdfRenderer();
            var html = new StringBuilder();
            html.Append($"<h1>Hero List </h1>");
            

            foreach (var heroName in heroNames)
            {
                html.Append($"<p>Hero: {heroName}</p>");
                heroCount++;
                Thread.Sleep(200);
            }

            var file = pdf.RenderHtmlAsPdf(html.ToString());
            file.SaveAs(path);
            ResultPath = path;
            IsReady = true;
            return true;

        }
    }
}
