using BusinessLayerInterfaces.UserServices;
using System.Text;

namespace GamerShop.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public int PerfomedUserCount { get; private set; }
        public int AllUserCount { get; private set; }
        public bool IsReady { get; private set; }
        public string? ResultPath { get; private set; }

        public bool GeneratePdfWithUsers(string path, List<string> userNames)
        {
            AllUserCount = userNames.Count();
            var renderer = new ChromePdfRenderer();
            var htmlSb = new StringBuilder();
            htmlSb.Append($"<h1>User list from web site</h1>");

            foreach (var userName in userNames)
            {
                htmlSb.Append($"<p>User: {userName}</p>");
                PerfomedUserCount++;

                // Smiluate comlex calculation
                Thread.Sleep(200);
            }

            var file = renderer.RenderHtmlAsPdf(htmlSb.ToString());
            file.SaveAs(path);
            
            ResultPath = path;
            IsReady = true;

            return true;
        }
    }
}
