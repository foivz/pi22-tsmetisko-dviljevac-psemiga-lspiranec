using Aspose.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Upravljanje_provjera_podataka
{
    public class UprProPodataka
    {
        public void GeneriranjePDF(string tekst)
        {
            Document document = new Document();
            Page page = document.Pages.Add();
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(tekst));
            document.Save("document.pdf");
        }
    }
}
